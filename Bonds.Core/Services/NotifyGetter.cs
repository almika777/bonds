using Bonds.Common.Options;
using Bonds.Core.Dto;
using Bonds.Core.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Bonds.Core.Services
{
    public class NotifyGetter : INotifyGetter
    {
        private readonly ITcsService _tcsService;
        private readonly ILogger<NotifyGetter> _logger;

        public NotifyGetter(
            ITcsService tcsService,
            ILogger<NotifyGetter> logger)
        {
            _logger = logger;
            _tcsService = tcsService;
        }

        public async Task<List<NotifyModel>> GetNotifiesByUser(long userId)
        {
            var bondsCandles = await _tcsService.GetProcessedBondsCandles();

            if (bondsCandles.Count < 1)
            {
                _logger.LogWarning("Нет бумаг с нужной разницей за день");
                return Enumerable.Empty<NotifyModel>().ToList();
            }

            var res = bondsCandles
                .Select(x => new NotifyModel
                {
                    ISIN = x.ISIN,
                    Name = x.Name,
                    Url = _tcsService.GetUrl(x.ISIN),
                    DifferencePercent = x.OpenCloseDifference,
                    Min = x.Min,
                    Max = x.Max,
                }).ToList();


            _logger.LogWarning($"Количество бумаг с разницей в Тинькофф: {res.Count}");

            return res;
        }
    }

}
