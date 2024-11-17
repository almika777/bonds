using System.Globalization;
using Bonds.Common;
using Bonds.DataProvider;
using Bonds.DataProvider.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;
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
            var bond = await _context.Bonds.SingleOrDefaultAsync(x => x.ISIN == value);
            var bondExtended = await _context.BondsExtended.SingleOrDefaultAsync(x => x.ISIN == value);
            var emitterBonds = await _context.BondsExtended
                .Where(x => x.EmitterId == bondExtended!.EmitterId)
                .Join(_context.Bonds, x => x.ISIN, x => x.ISIN, (x, y) => y)
                .ToListAsync();

            return new Message
            {
                Text = GetMessage(bond, emitterBonds),
            };
        }

        private string GetMessage(BondEntity bond, List<BondEntity> emitterBonds)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Эмитент: {bond.SecName}");
            sb.AppendLine($"<a href=\"{GlobalConstants.MoexSiteBondUrlPart + bond.ISIN}\">{bond.ISIN}</a>: {bond.YieldAtPrevWaPrice}%");
            sb.AppendLine($"Дней до погашения или оферты: {DaysForYieldCalculate(bond)}");
            sb.AppendLine($"Купонов в месяц: {365 / bond.CouponPeriod}");
            sb.AppendLine($"Флоатер (возможно): {Floater(bond)}");
            sb.AppendLine("");

            sb.AppendLine("Другие бумаги эмитента:");

            foreach (var x in emitterBonds.OrderByDescending(x => x.YieldAtPrevWaPrice))
            {
                sb.AppendLine($"Эмитент: {x.SecName}");
                sb.AppendLine($"<code>{x.ISIN}</code>: {x.YieldAtPrevWaPrice}%");
                sb.AppendLine($"Дней до погашения (оферты): {DaysForYieldCalculate(x)}");
                sb.AppendLine("");
            }
            return sb.ToString();
        }

        private string DaysForYieldCalculate(BondEntity bond)
        {
            var date = bond.OfferDate ?? bond.MatDate;

            return date == null 
                ? "Бессрочная" 
                : Math.Round((date.Value - DateTime.Now).TotalDays).ToString("");
        }

        private string Floater(BondEntity bond) => bond.IsFloater ? "Да" : "Нет";
    }

    public interface IIsinHandler
    {
        Task<Message> Handle(string value);
    }
}
