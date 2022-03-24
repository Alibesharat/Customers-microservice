using CustomerService.Contracts;
using CustomerService.Impelimentions;
using MessageBroker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace CustomerService
{
    class Program
    {
       static IStoreService StoreService;
        static async Task Main(string[] args)
        {


            var host = CreateHostBuilder(args).Build();
            //Do Code

            StoreService = host.Services.GetRequiredService<IStoreService>();
            var reciver = host.Services.GetRequiredService<IMessageReciver>();
            reciver.SubscribeToCustomerTopic();
            reciver.MessageRecived += Reciver_MessageRecived;
            

            await host.RunAsync();

        }

        private static void Reciver_MessageRecived(object sender, Kafka.Public.RawKafkaRecord e)
        {
            Console.WriteLine(e.GetValue());
            StoreService.Save(e.GetKey(),e.GetValue());
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
             .ConfigureServices((_, services) =>
                 services.AddMessageSender()
                 .AddMessegeReciver()
                 .AddSingleton<IStoreService, EventStoreService>()
                 .AddLogging());


        }
    }










}
