using Bonds.DataProvider.Repositories;
using Bonds.DataProvider.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bonds.DataProvider.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataProvider(this IServiceCollection services, IConfiguration? config = null)
        {
            services.AddScoped<IUserBondsRepository, UserBondsRepository>();
            return services;
        }
    }
}
