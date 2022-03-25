using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace OrderServiceApp
{
    class Program
    {
        static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().Run();
        }



        public static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
             .ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStartup<Startup>().ConfigureKestrel(options =>
                 {
                     options.Listen(IPAddress.Any, 10043, listenOptions =>
                     {
                         listenOptions.Protocols = HttpProtocols.Http2;

                     });
                 });
             });
    }










}
