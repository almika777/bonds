using Bonds.Telegram.Commands;
using Bonds.Telegram.Services;
using Bonds.Telegram.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Bonds.Telegram.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTelegramServices(this IServiceCollection services)
        {
            services.AddScoped<ITelegramClient, TelegramClient>();
            services.AddScoped<ITelegramService, TelegramService>();
            services.AddScoped<IUpdateHandler, UpdateHandler>();
            services.AddScoped<IMessageCommandFactory, MessageCommandFactory>();
            services.AddCommands();
            return services;
        }

        private static void AddCommands(this IServiceCollection services)
        {
            services.AddScoped<IIsinHandler, IsinHandler>();
            services.AddScoped<IMessageCommandHandler, UnknownMessageCommand>();
        }
    }
}
