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