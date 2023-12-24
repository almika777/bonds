using Bonds.Core.Services;
using Bonds.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Bonds.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddHttpClient("moex", httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://iss.moex.com/iss/");
            });
            services.AddScoped<IBondsDataClient, BondsDataClient>();
            services.AddScoped<IProfitabilityCalculatorService, ProfitabilityCalculatorService>();
            return services;
        }
    }
}
