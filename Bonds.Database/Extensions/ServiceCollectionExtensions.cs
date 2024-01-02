using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bonds.Database.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
        {
            var con = config.GetConnectionString("BondsConnectionString");
            services.AddDbContextPool<BondsContext>(x => x.UseNpgsql(config.GetConnectionString("BondsConnectionString")));
            return services;
        }

    }
}