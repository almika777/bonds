using Microsoft.EntityFrameworkCore;

namespace Bonds.DataProvider.Tests
{
    public abstract class BaseSqliteTest
    {
        protected BondsContext Database { get; set; }

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BondsContext>()
                .UseSqlite($"Data Source={Guid.NewGuid()}.db")
                .Options;
            Database = new BondsContext(options);
        }

        [TearDown]
        public async Task TearDown()
        {
            await Database.Database.EnsureDeletedAsync();

            File.Delete(Database.DbPath);
        }
    }
}
