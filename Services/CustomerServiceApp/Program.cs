using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace CustomerServiceApp
{
    class Program
    {
        static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().Run();
        }



        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .ConfigureKestrel(options =>
            {
                options.ListenLocalhost(10042, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http2;
                });
            })
            .UseStartup<Startup>();
    }










}
