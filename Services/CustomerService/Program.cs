using CustomerService.Contracts;
using CustomerService.Impelimentions;
using MessageBroker;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace CustomerService
{
    class Program
    {
        static IStoreService StoreService;
        static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().Run();
            //var host = CreateHostBuilder(args).Build();
            ////Do Code

            //StoreService = host.Services.GetRequiredService<IStoreService>();
            //var reciver = host.Services.GetRequiredService<IMessageReciver>();
            //reciver.SubscribeToCustomerTopic();
            //reciver.MessageRecived += Reciver_MessageRecived;

            //var data = StoreService.Fetch("Ali");
            //await host.RunAsync();

        }

        private static void Reciver_MessageRecived(object sender, Kafka.Public.RawKafkaRecord e)
        {
            StoreService.Append(e.GetKey(), e.GetValue());
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }










}
