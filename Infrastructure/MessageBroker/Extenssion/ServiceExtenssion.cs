using MessageBroker;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtenssion
    {
        public static void AddMessageSender(this IServiceCollection services)
        {
            services.AddSingleton<IMessageSender, KafkaProducer>();
        }

        public static void AddMessegeReciver(this IServiceCollection services)
        {
            services.AddSingleton<IMessageReciver, KafkaReciver>();
        }
    }
}
