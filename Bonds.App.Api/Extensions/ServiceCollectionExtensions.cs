using Bonds.Common.Options;
using Bonds.Core.Jobs;
using Hangfire;

namespace Bonds.App.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJobs(this IServiceCollection services)
    {
        services.AddSingleton<IMoexBondInfoJob, MoexBondInfoJob>();
        return services;
    }   

    public static IServiceCollection AddApplicationOptions(this IServiceCollection services, IConfiguration config)
    {
        return services.AddSingleton(config.GetSection(nameof(BondsPortfolioOptions)).Get<BondsPortfolioOptions>());
    }

}