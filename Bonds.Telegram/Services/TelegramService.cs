using Bonds.Telegram.Services.Interfaces;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;

namespace Bonds.Telegram.Services
{
    internal class TelegramService : ITelegramService
    {
        private readonly ITelegramBotClient _telegramBotClient;

        public TelegramService(ITelegramBotClient telegramBotClient)
        {
            _telegramBotClient = telegramBotClient;
        }

        public Task SendMessage(string chatId, string message)
        {
            return _telegramBotClient.SendMessageAsync(chatId, message);
        }
    }
}
