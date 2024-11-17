
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.DependencyInjection
{
    public static class DataDependencies
    {
        public static IServiceCollection RegisterDataDependencies(this IServiceCollection services, IConfiguration configuration)
        {
           
           services.AddScoped<IContactData, ContactData>();
            services.AddSingleton<IDataHelper, JsonDataHelper>();
            return services;
        }
    }
}
