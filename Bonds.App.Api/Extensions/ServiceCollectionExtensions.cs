using Bonds.Common.Options;
using Bonds.Core.Jobs;

namespace Bonds.App.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJobs(this IServiceCollection services)
    {
        services.AddSingleton<IJob, MoexBondInfoJob>();
        return services;
    }

    public static IServiceCollection AddApplicationOptions(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton(config.GetSection(nameof(JobsOptions)).Get<JobsOptions>());
        return services;
    }

}