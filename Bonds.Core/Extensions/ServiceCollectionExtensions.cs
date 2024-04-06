using Bonds.Core.Services;
using Bonds.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bonds.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration? config = null)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            var config1 = services.FirstOrDefault(x => x.ServiceType == typeof(IConfiguration));
            services.AddHttpClient("moex", httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://iss.moex.com/iss/");
            });
            services.AddScoped<IMoexHttpDataClient, MoexHttpDataClient>();
            var bb = config?.GetSection("ConnectionStrings");
            return services;
        }
    }
}
