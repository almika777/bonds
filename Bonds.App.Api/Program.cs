using Bonds.App.Api.Extensions;
using Bonds.App.Api.HostedServices;
using Bonds.Core.Extensions;
using Bonds.DataProvider.Extensions;

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

            var app = builder.Build();

            app.Run();
        }
    }
}