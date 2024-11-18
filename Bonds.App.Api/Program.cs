using Bonds.App.Api.Extensions;
using Bonds.Common.Options;
using Bonds.Core.Extensions;
using Bonds.Core.Jobs;
using Bonds.Core.Mappers;
using Bonds.DataProvider.Extensions;
using Bonds.Telegram.Extensions;
using Bonds.Telegram.Services.Interfaces;
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
            builder.Services.AddDataProvider(builder.Configuration);
            builder.Services.AddCoreServices();
            builder.Services.AddTelegramServices();
            builder.Services.AddTelegram(builder.Configuration);
            builder.Services.AddHangfire(x =>
            {
                x.UseSimpleAssemblyNameTypeSerializer();
                x.UseRecommendedSerializerSettings();
                x.UsePostgreSqlStorage(x => x.UseNpgsqlConnection(builder.Configuration.GetConnectionString("Bonds")));
            });
            builder.Services.AddHangfireServer();
            builder.Services.AddMemoryCache();
            builder.Services.AddAutoMapper(typeof(SimpleMapper));
            builder.Services.AddJobs();

            var app = builder.Build();
            app.UseHangfireDashboard("/hangfire",new DashboardOptions
            {
                IgnoreAntiforgeryToken = true
            });
            RegisterJobs(app);
            using var scope = app.Services.CreateScope();
            scope.ServiceProvider.GetRequiredService<ITelegramClient>().Receive();

            app.Run();
        }

        private static void RegisterJobs(IHost app)
        {
            var jobs = app.Services.GetServices<IJob>();
            foreach (var job in jobs)
            {
                var cron = app.Services.GetRequiredService<JobsOptions>();
                var typeName = job.GetType().Name;

                //RecurringJob.AddOrUpdate<IJob>(typeName, x => job.Execute(), cron.Settings[typeName].Cron);
                RecurringJob.AddOrUpdate(typeName, () => job.Execute(), cron.Settings[typeName].Cron);
            }
        }
    }
}