using Bonds.DataProvider.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Bonds.DataProvider.Tests
{
    public class BondsContextMappingTests : BasePostgreTests
    {

        [Test]
        public async Task BondsEntity()
        {
            var now = DateTime.UtcNow;
            var bond = new BondEntity
            {
                ISIN = "ISIN",
                UpdatedDate = now,
                Bid = 1.1,
                Ask = 1.2,
                Spread = 0.1,
                Open = 1,
                Low = 2,
                High = 3,
                Last = 4,
                Qty = 5,
                Value = 6,
                Yield = 7,
                WaPrice = 8,
                YieldAtWaPrice = 9,
                CouponValue = 1,
                MarketPriceToday = 2,
                MarketPrice = 3,
                TradesCount = 4,
                VolToday = 5,
                ValToday = 6,
                UpdateTime = DateTime.UtcNow,
                Change = 1,
                PriceMinusPrevWaPrice = 2,
                YieldLastCoupon = 3,
                SeqNum = 2,
            };

            await Database.Bonds.AddAsync(bond);
            await Database.SaveChangesAsync();

            var res = await Database.Bonds.ToListAsync();

            res.Should().NotBeNullOrEmpty();
            res.Count.Should().Be(1);
            var first = res[0];
        }
    }
}