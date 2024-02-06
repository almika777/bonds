using Bonds.Core.Dto;
using Bonds.Core.Enums;
using Bonds.Core.Helpers;
using Bonds.Core.Results;
using Bonds.Core.Services.Interfaces;

namespace Bonds.Core.Services
{
    public class ProfitabilityCalculatorService : IProfitabilityCalculatorService
    {
        private readonly IBondsDataClient _bondsDataClient;

        public ProfitabilityCalculatorService(IBondsDataClient bondsDataClient)
        {
            _bondsDataClient = bondsDataClient;
        }

        public async Task<double> Calculate(ProfitabilityDto model)
        {
            switch (model.ProfitabilityType)
            {
                case ProfitabilityType.Current:
                    break;
                case ProfitabilityType.ModifyCurrent:
                    break;
                case ProfitabilityType.Simple:
                    return await GetSimpleProfit(model);
                case ProfitabilityType.Effective:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return 0;
        }

        private async Task<double> GetSimpleProfit(ProfitabilityDto model)
        {

            return 1;
        }

        /// <summary>
        /// Накопленный доход облигации
        /// </summary>
        /// <returns></returns>
        public double GetNkd(BondInfo data)
        {
            var now = DatesHelper.GetMscNow();
            var couponDaysPeriod = 365 / data.CouponFrequency;
            var dateForCalculate = (now - data.IssueDate).TotalDays > couponDaysPeriod
                ? data.CouponDate.AddDays(-couponDaysPeriod)
                : data.IssueDate;

            double daysGone = (now - dateForCalculate).Days;
            var result = Math.Round(data.FaceValue * (data.CouponPercent / 100) * (daysGone / 365), 2);
            return result;
        }
    }
}
