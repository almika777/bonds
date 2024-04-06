using Bonds.Common.Options;

namespace Bonds.App.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {

        return services;
    }   

    public static IServiceCollection AddApplicationOptions(this IServiceCollection services, IConfiguration config)
    {
        return services.AddSingleton(config.GetSection(nameof(BondsPortfolioOptions)).Get<BondsPortfolioOptions>());
    }

}