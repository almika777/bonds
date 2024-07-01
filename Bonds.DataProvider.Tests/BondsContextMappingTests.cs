using Bonds.DataProvider.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Bonds.DataProvider.Tests
{
    public class BondsContextMappingTests : BaseSqliteTest
    {

        [Test]
        public async Task TelegramUserEntity()
        {
            var user = new TelegramUserEntity
            {
                TelegramId = "123",
                BondCriteria = new UserBondCriteriaEntity
                {
                    IgnoreNames = new List<string>() { "1", "2" },
                    DayChanges = -0.4,
                    MinCouponPercent = 19.4
                },

            };
            await Database.Users.AddAsync(user);
            await Database.SaveChangesAsync();
            var res = await Database.Users.ToListAsync();

            res.Should().NotBeNullOrEmpty();
            res[0].Id.Should().BePositive();
            res[0].BondCriteria.Should().BeEquivalentTo(user.BondCriteria);
        }
    }
}