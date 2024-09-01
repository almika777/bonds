using Bonds.Core.Jobs;
using Bonds.Core.Services;
using Bonds.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.BotAPI;

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

            services.AddSingleton<IMoexHttpDataClient, MoexHttpDataClient>();
            services.AddSingleton<IBondsEventProviderService, BondsEventProviderService>();
            services.AddSingleton<ITelegramService, TelegramService>();
            services.AddSingleton<ITelegramMessageService, TelegramMessageService>();

            return services;
        }

        public static IServiceCollection AddTelegram(this IServiceCollection services, IConfiguration config)
        {
            return services.AddSingleton<ITelegramBotClient>(new TelegramBotClient(config["TelegramBotToken"]));
        }
    }
}
