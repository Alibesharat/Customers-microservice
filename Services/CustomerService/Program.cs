using MessageBroker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace CustomerService
{
    class Program
    {
        static async Task Main(string[] args)
        {


            var host = CreateHostBuilder(args).Build();
            //Do Code
            



            await host.RunAsync();

        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
             .ConfigureServices((_, services) =>
                 services.AddMessageSender()
                 .AddMessegeReciver()
                 .AddLogging());


        }
    }










}
