using Bonds.Common;
using Bonds.DataProvider;
using Bonds.DataProvider.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Bonds.Core.Dto;
using Telegram.BotAPI.AvailableTypes;

namespace Bonds.Telegram
{
    public class IsinHandler : IIsinHandler
    {
        private readonly BondsContext _context;

        public IsinHandler(BondsContext context)
        {
            _context = context;
        }

        public async Task<Message> Handle(string value)
        {
            var extended = await _context.BondsExtended.SingleOrDefaultAsync(x => x.ISIN == value.ToUpper());

            if (extended == null)
                throw new Exception("Данные ISIN не найден, попробуйте позже");

            var marketdata = await _context.BondsMarketdata.SingleAsync(x => x.ISIN == value.ToUpper());
            var security = await _context.BondsSecurities.SingleAsync(x => x.ISIN == value.ToUpper());
            var bondFull = new BondFull
            {
                Marketdata = marketdata,
                Security = security,
                Extended = extended
            };

            var emitterBonds = await _context.BondsExtended
                .Where(x => x.EmitterId == extended.EmitterId && x.ISIN != extended.ISIN)
                .Join(_context.BondsMarketdata, x => x.ISIN, x => x.ISIN, (x, y) => new
                {
                    Extended = x,
                    Marketdata = y
                }).Join(_context.BondsSecurities, x => x.Extended.ISIN, x => x.ISIN, (x, y) => new BondFull
                {
                    Extended = x.Extended,
                    Marketdata = x.Marketdata,
                    Security = y
                })
                .ToListAsync();

            return new Message
            {
                Text = GetMessage(bondFull, emitterBonds),
            };
        }

        private string GetMessage(
            BondFull bond,
            IReadOnlyCollection<BondFull>? emitterBonds = null)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Эмитент: {bond.Security.SecName}");
            sb.AppendLine($"<a href=\"{GlobalConstants.MoexSiteBondUrl(bond.Extended.ISIN)}\">{bond.Extended.ISIN}</a>");
            sb.AppendLine($"Доходность: {bond.Marketdata.YieldAtWaPrice}");
            sb.AppendLine($"Текущая цена: {bond.Marketdata.CurrentPrice}");
            sb.AppendLine($"Изменения за день: {bond.Marketdata.PriceMinusPrevWaPrice}");
            sb.AppendLine($"Дней до погашения или оферты: {DaysForYieldCalculate(bond.Security)}");
            sb.AppendLine($"Купонов в месяц: {365 / bond.Security.CouponPeriod}");
            sb.AppendLine($"Флоатер (возможно): {Floater(bond.Security)}");
            sb.AppendLine("");

            sb.AppendLine("Другие бумаги эмитента:");

            if (emitterBonds != null)
            {
                foreach (var x in emitterBonds)
                {
                    sb.AppendLine($"Эмитент: {bond.Security.SecName}");
                    sb.AppendLine($"<code>{x.Security.ISIN}</code>: {x.Marketdata.YieldAtWaPrice}%");
                    sb.AppendLine($"Дней до погашения (оферты): {DaysForYieldCalculate(x.Security)}");
                    sb.AppendLine("");
                }
            }

            sb.AppendLine($"🕐 Актуально на: {bond.Marketdata.UpdateTime}");

            return sb.ToString();
        }

        private string DaysForYieldCalculate(BondSecurityEntity bond)
        {
            var date = bond.OfferDate ?? bond.MatDate;

            return date == null
                ? "Бессрочная"
                : Math.Round((date.Value - DateTime.Now).TotalDays).ToString("");
        }

        private string Floater(BondSecurityEntity bond) => bond.IsFloater ? "Да" : "Нет";
    }

    public interface IIsinHandler
    {
        Task<Message> Handle(string value);
    }
}
