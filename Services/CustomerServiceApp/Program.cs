using GrpcModelFirst;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace CustomerServiceApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = CreateHostBuilder(args).Build();
            var customer = (ICustomerService)builder.Services.GetService((typeof(ICustomerService)));
         
            
            builder.Run();

        }



        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>().ConfigureKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 10042, listenOptions =>
                    {
                        listenOptions.Protocols = HttpProtocols.Http2;

                    });
                });
            });
    }










}
