using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using WebApi.Config;

namespace WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await new WebHostBuilder()
                .UseKestrel(options => { options.Listen(IPAddress.Any, ConfigManager.Get().Port); })
                .UseStartup<Startup>()
                .Build()
                .RunAsync();

            Cleanup();
        }

        private static void Cleanup() { }
    }
}
