using Bonds.App.Api.Extensions;
using Bonds.App.Api.HostedServices;
using Bonds.Core.Extensions;
using Bonds.Core.Jobs;
using Bonds.DataProvider.Extensions;
using Hangfire;
using Hangfire.PostgreSql;

namespace Bonds.App.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddApplicationOptions(builder.Configuration);
            builder.Services.AddDataProvider();
            builder.Services.AddCoreServices();
            builder.Services.AddTelegram(builder.Configuration);
            builder.Services.AddTinkoff(builder.Configuration);
            builder.Services.AddHostedService<RecurringHostedService>();
            builder.Services.AddHangfire(x =>
            {
                x.UseSimpleAssemblyNameTypeSerializer();
                x.UseRecommendedSerializerSettings();
                x.UsePostgreSqlStorage(x => x.UseNpgsqlConnection(builder.Configuration.GetConnectionString("Bonds")));
            });
            builder.Services.AddJobs();

            var app = builder.Build();

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            RecurringJob.AddOrUpdate<IMoexBondInfoJob>(nameof(IMoexBondInfoJob), x => x.Execute(), Cron.Minutely);

            app.Run();
        }
    }
}