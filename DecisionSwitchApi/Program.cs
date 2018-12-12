using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Pivotal.Extensions.Configuration.ConfigServer;

namespace Decision.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
         WebHost.CreateDefaultBuilder(args)
            .UseCloudFoundryHosting()
            .AddConfigServer()
            .UseStartup<Startup>();

    }
}