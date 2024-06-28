using Bonds.Core.Dto;
using Bonds.Core.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Bonds.Core.Services
{
    public class TelegramMessageService : ITelegramMessageService
    {
        private TimeSpan LifeTime => TimeSpan.FromMinutes(int.Parse(_config["JobDelayMinutes"]) + 5);

        private readonly IMemoryCache _cache;
        private readonly IConfiguration _config;

        public TelegramMessageService(IMemoryCache cache, IConfiguration config)
        {
            _cache = cache;
            _config = config;
        }

        public List<string> BuildBondsMessage(List<NotifyModel> notifies)
        {
            var res = new List<string>();
            var sb = new StringBuilder();

            notifies.ForEach(x =>
            {
                if (_cache.TryGetValue(GetKey(x.ISIN), out _))
                    return;

                sb.Append(BuildBondsMessage(x));
                sb.AppendLine();

                if (sb.Length >= 3000)
                {
                    res.Add(sb.ToString());
                    sb.Clear();
                }

                _cache.Set(GetKey(x.ISIN), 1, LifeTime);
            });

            if (res.Count == 0)
                res.Add(sb.ToString());

            return res;
        }

        private string BuildBondsMessage(NotifyModel notify)
        {
            var sb = new StringBuilder();

            sb.AppendLine(notify.ISIN);
            sb.AppendLine(notify.Name);
            sb.AppendLine(notify.Url);
            sb.AppendLine($"Мин: {notify.Min} | " +
                          $"Макс: {notify.Max} | " +
                          $"Разница: {notify.DifferencePercent}");

            return sb.ToString();
        }

        private string GetKey(string isin)
        {
            return isin;
        }
    }
}
