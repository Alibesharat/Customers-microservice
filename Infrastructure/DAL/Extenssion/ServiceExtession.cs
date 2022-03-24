using DAl.Impelimentions;
using DAL;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtession
    {
        public static void AddStoreService(this IServiceCollection services)
        {
            services.AddSingleton<IStoreService, EventStoreService>();
        }
    }
}
