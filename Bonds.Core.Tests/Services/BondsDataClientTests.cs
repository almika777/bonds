using Bonds.Core.Extensions;
using Bonds.Core.Services.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Bonds.Core.Tests.Services
{
    public class BondsDataClientTests
    {
        private ServiceProvider _services;

        [SetUp]
        public void Setup()
        {
            _services = new ServiceCollection().AddCoreServices().BuildServiceProvider();
        }

        [Test]
        public async Task Test1()
        {
            var service = _services.GetRequiredService<IBondsDataClient>();

            var result = await service.GetBondsInfo("RU000A1077V4");

            result.Should().NotBeNull();
            result.Description.Data.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task Test2()
        {
            var service = _services.GetRequiredService<IBondsDataClient>();

            await service.GetBondsQuotes();


        }
    }
}