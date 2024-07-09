using Bonds.Core.Extensions;
using Bonds.Core.Services.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Bonds.Core.Tests.Services
{
    public class MoexHttpDataClientTests
    {
        private ServiceProvider _services;

        [SetUp]
        public void Setup()
        {
            _services = new ServiceCollection().AddCoreServices().BuildServiceProvider();
        }

        [Test]
        public async Task GetBondsInfoTest()
        {
            var service = _services.GetRequiredService<IMoexHttpDataClient>();

            var result = await service.GetBondsInfo("RU000A1077V4");

            result.Should().NotBeNull();
            result.Description.Data.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task GetAllBondsTest()
        {
            var service = _services.GetRequiredService<IMoexHttpDataClient>();

            var response = await service.GetAllBonds();
        }        
        
        [Test]
        public async Task GetAllBondsMarketdataTest()
        {
            var service = _services.GetRequiredService<IMoexHttpDataClient>();

            var response = await service.GetAllBondsMarketdata();
        }

        [Test]
        public async Task GetBondsTradesTest()
        {
            var service = _services.GetRequiredService<IMoexHttpDataClient>();

            var response = await service.GetBondsTrades("RU000A106WZ2");
        }
    }
}