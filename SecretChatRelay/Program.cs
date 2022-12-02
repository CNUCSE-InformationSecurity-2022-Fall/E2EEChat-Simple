using SecretChatRelay;
using System.Diagnostics;
using System.Text;

namespace SecretCharRelay
{
    public class Program
    {
        public static byte[]? ServerPubKey;
        public static byte[]? ServerPriKey;

        public static string? ExecuteScript(string scriptName, params string[] args)
        {
            try
            {
                StringBuilder result = new StringBuilder();

                var process = new Process();
                process.StartInfo = new ProcessStartInfo()
                {
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = "python-scripts",
                    FileName = "python.exe",
                    Arguments = scriptName
                };

                var dataReceivedHandler = new DataReceivedEventHandler((sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        result.Append(e.Data + "\n");
                    }
                });

                process.ErrorDataReceived += dataReceivedHandler;
                process.OutputDataReceived += dataReceivedHandler;

                process.Start();

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                foreach (var arg in args)
                {
                    var argTemp = arg;

                    if (arg.EndsWith("\n"))
                        argTemp = arg.Substring(0, arg.Length - 1);

                    process.StandardInput.WriteLine(argTemp);
                }

                process.WaitForExit();

                var output = result.ToString();
                return process.ExitCode == 0 ? output : "";
            }
            catch (Exception ex)
            {
               return null;
            }
        }

        public static void GenerateKeys()
        {
            string[] genKeyList;

            if (File.Exists("serverKeyProfile"))
            {
                genKeyList = new string[2];

                var keyProfile = File.ReadAllText("serverKeyProfile").Split('\n');
                genKeyList[0] = keyProfile[0];
                genKeyList[1] = keyProfile[1];
            }
            else
            {
                var genKeys = ExecuteScript("generate-keys.py");
                genKeyList = genKeys.Split('\n');

                genKeyList[0] = genKeyList[1];
                genKeyList[1] = genKeyList[2];

                var kpFile = File.OpenWrite("serverKeyProfile");
                var writer = new StreamWriter(kpFile);

                writer.WriteLine(genKeyList[0]);
                writer.WriteLine(genKeyList[1]);

                writer.Close();
                kpFile.Close();
            }

            try
            {
                ServerPubKey = Convert.FromBase64String(genKeyList[0]);
                ServerPriKey = Convert.FromBase64String(genKeyList[1]);
            }
            catch
            {
                File.Delete("serverKeyProfile");
                GenerateKeys();
            }
        }

        public static string? CreateCertificate(string name, string pubKey)
        {
            var serverPriKey = Convert.ToBase64String(ServerPriKey);
            var serverPubKey = Convert.ToBase64String(ServerPubKey);

            var createdCert = ExecuteScript("create-certificate.py", name, pubKey, serverPubKey, serverPriKey);
            var certPath = $"certificates/{name}.json";

            if (File.Exists(certPath))
                File.Delete(certPath);

            File.WriteAllText(certPath, createdCert);

            return createdCert;
        }

        public static void Main(string[] args)
        {
            GenerateKeys();

            var builder = WebApplication.CreateBuilder(args);
     
            builder.Services.AddSignalR();
            builder.Services.AddLogging();
            builder.Services.AddRazorPages();
            
            // builder.WebHost.UseUrls("http://*:8080");
            
            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapHub<ChatRelayHub>("/Chat");
            });
            
            app.Run();
        }
    }
}