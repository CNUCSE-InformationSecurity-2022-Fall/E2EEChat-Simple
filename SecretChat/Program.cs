using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecretChat
{
    internal static class Program
    {
        public static string ExecuteScript(DebuggingForm form, string scriptName, params string[] args)
        {
            DebuggingForm _debuggingForm = null;    
            
            if (form != null)
                _debuggingForm = form;

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

                _debuggingForm?.AppendLog("Executing Script:: {0}\r\n", scriptName);

                for (var i = 0; i < args.Length; ++i)
                {
                    _debuggingForm?.AppendLog("With Args {0}: {1}\r\n", i, args[i]);
                }

                _debuggingForm?.AppendLog("==========\r\n");

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

                _debuggingForm?.AppendLog(output.Replace("\n", "\r\n"));
                return process.ExitCode == 0 ? output : "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "스크립트 실행 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        [STAThread]
        static void Main()
        {
            if (!Directory.Exists("python-scripts"))
                Directory.CreateDirectory("python-scripts");

            if (!Directory.Exists("certificates"))
                Directory.CreateDirectory("certificates");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
