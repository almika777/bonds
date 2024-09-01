using Microsoft.EntityFrameworkCore;
using Testcontainers.PostgreSql;

namespace Bonds.DataProvider.Tests
{
    public class BasePostgreTests
    {
        protected BondsContext Database { get; set; }

        private readonly PostgreSqlContainer _container = new PostgreSqlBuilder()
            .WithImage("postgres:16")
            .Build();

        private string _conString;

        [SetUp]
        public async Task Setup()
        {
            await _container.StartAsync();

            _conString = _container.GetConnectionString();
            var options = new DbContextOptionsBuilder<BondsContext>().UseNpgsql(_conString).Options;
            Database = new BondsContext(options);
        }

        [TearDown]
        public async Task TearDown()
        {
            await _container.StopAsync();
        }
    }
}
