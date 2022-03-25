using Validators;
using Validators.Impelimetns;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtenssion
    {
        public static void AddValidator(this IServiceCollection service)
        {
            service.AddSingleton<ICustomeValidator, CustomeValidator>();
        }
    }
}
