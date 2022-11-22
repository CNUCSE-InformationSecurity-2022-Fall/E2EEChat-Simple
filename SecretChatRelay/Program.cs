using SecretChatRelay;

namespace SecretCharRelay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
     
            builder.Services.AddSignalR();
            builder.Services.AddLogging();
            builder.Services.AddRazorPages();
            
            builder.WebHost.UseUrls("http://*:8080");
            
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