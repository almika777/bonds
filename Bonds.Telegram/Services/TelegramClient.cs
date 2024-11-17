using Bonds.Telegram.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Telegram.BotAPI;
using Telegram.BotAPI.GettingUpdates;
#pragma warning disable CS4014

namespace Bonds.Telegram.Services
{
    public class TelegramClient : ITelegramClient
    {
        private readonly ITelegramBotClient _telegramBot;
        private readonly IUpdateHandler _updateHandler;
        private readonly ILogger<TelegramClient> _logger;
        private readonly CancellationTokenSource _source;

        public TelegramClient(ITelegramBotClient telegramBot, IUpdateHandler updateHandler, ILogger<TelegramClient> logger)
        {
            _telegramBot = telegramBot;
            _updateHandler = updateHandler;
            _logger = logger;
            _source = new CancellationTokenSource();
        }

        public async Task Receive()
        {
            int? offset = null;
            while (!_source.IsCancellationRequested)
            {
                var updates = await _telegramBot.GetUpdatesAsync(offset, timeout: 2);

                foreach (var update in updates)
                {
                    offset = update.UpdateId + 1;
                    try
                    {
                        _updateHandler.Update(update);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Пу пу пууу");
                    }

                    if (_source.IsCancellationRequested)
                        break;
                }
            }
        }

        public void Stop()
        {
            _source.Cancel();
        }
    }
}
