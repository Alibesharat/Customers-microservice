using MessageBroker;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtenssion
    {
        public static IServiceCollection AddMessageSender(this IServiceCollection services)
        {
           return services.AddSingleton<IMessageSender, KafkaProducer>();
        }

        public static IServiceCollection AddMessegeReciver(this IServiceCollection services)
        {
            return services.AddSingleton<IMessageReciver, KafkaReciver>();
        }
    }
}
