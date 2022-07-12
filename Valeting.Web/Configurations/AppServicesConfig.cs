using Valeting.Application.Services;
using Valeting.Application.Services.Interfaces;

namespace Valeting.Web.Configurations
{
    public static class AppServicesConfig
    {
        public static IServiceCollection ResolveAppServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            return services;
        }
    }
}
