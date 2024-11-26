using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bonds.DataProvider.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataProvider(this IServiceCollection services, IConfiguration? config)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddDbContextFactory<BondsContext>(x =>
            {
                x.UseNpgsql(config.GetConnectionString("Bonds"));
                x.EnableSensitiveDataLogging();
            });
            return services;
        }
    }
}
