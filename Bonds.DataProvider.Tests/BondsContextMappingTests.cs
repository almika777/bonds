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
            var bond = new BondSecurityEntity
            {
                ISIN = "ISIN",

            };

            await Database.BondsSecurities.AddAsync(bond);
            await Database.SaveChangesAsync();

            var res = await Database.BondsSecurities.ToListAsync();

            res.Should().NotBeNullOrEmpty();
            res.Count.Should().Be(1);
            var first = res[0];
        }
    }
}