using Bonds.Core.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;

namespace Bonds.Core.Jobs
{
    public class MoexTradesReader
    {
        private const string ChatId = "285783010";
        private readonly INotifyGetter _notifyGetter;
        private readonly ITelegramService _telegramService;
        private readonly ITelegramMessageService _telegramMessageService;
        private readonly ILogger<MoexTradesReader> _logger;

        public MoexTradesReader(
            INotifyGetter notifyGetter,
            ITelegramService telegramService,
            ITelegramMessageService telegramMessageService,
            ILogger<MoexTradesReader> logger)
        {
            _notifyGetter = notifyGetter;
            _telegramService = telegramService;
            _telegramMessageService = telegramMessageService;
            _logger = logger;
        }

        public async Task Read()
        {
            var users = new List<object>();//Users with chatId
            var notifies = await _notifyGetter.GetNotifiesByUser(1);

            if (notifies.Count < 1)
            {
                _logger.LogWarning("Нет в тиньке бумаг с нужной разницей");
                return;
            }

            var messages = _telegramMessageService.BuildBondsMessage(notifies);
            messages.ForEach(x => _telegramService.SendMessage(ChatId, x));
        }

    }
}
