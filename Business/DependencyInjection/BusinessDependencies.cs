
using Business;
using Data.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ESS.Business.DependencyInjection
{
    public static class BusinessDependencies
    {
        public static IServiceCollection RegisterBusinessDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDataDependencies(configuration);
            services.AddScoped<IContactBusiness, ContactBusiness>();

            return services;
        }
    }
}
