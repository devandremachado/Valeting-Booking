using Valeting.Domain.Core.Repositories;
using Valeting.Infra.Data.Context;
using Valeting.Infra.Data.Repositories;

namespace Valeting.Web.Configurations
{
    public static class RepositoryConfig
    {
        public static IServiceCollection ResolveRepositoryDependencies(this IServiceCollection services)
        {
            services.AddScoped<BookingContext>();

            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
