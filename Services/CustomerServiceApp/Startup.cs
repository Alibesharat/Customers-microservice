using CustomerServiceApp.Impelimentions;
using DAL.Options;
using GrpcModelFirst;
using MessageBroker.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerServiceApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<EventStoreDebSetting>(Configuration.GetSection("EventStoreDebSetting"));
            services.Configure<KafkaSettings>(Configuration.GetSection("KafkaSettings"));

            services.AddMessageSender();
            services.AddMessegeReciver();
            services.AddStoreService();
            services.AddGrpcServer();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ICustomerService>();
            });
        }



    }

}
