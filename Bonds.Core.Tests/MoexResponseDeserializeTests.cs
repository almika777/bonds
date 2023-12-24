using Microsoft.Extensions.DependencyInjection;
using Bonds.Core.Extensions;
using Bonds.Core.Helpers;
using FluentAssertions;
using Bonds.Core.Services.Interfaces;

namespace Bonds.Core.Tests
{
    public class MoexResponseDeserializeTests
    {
        private ServiceProvider _services;

        [SetUp]
        public void Setup()
        {
            _services = new ServiceCollection().AddCoreServices().BuildServiceProvider();
        }

        [Test]
        public async Task DeserializeTest()
        {
            var bondsDataClient = _services.GetRequiredService<IBondsDataClient>();
            var isin = "RU000A1077V4";
            var bondData = await bondsDataClient.GetBondsInfo(isin);

            var result = MoexResponseDeserializer.Deserialize(bondData.Description.Data);
            result.Isin.Should().Be(isin);
        }


        [Test]
        public async Task Deserialize1Test()
        {
            var bondsDataClient = _services.GetRequiredService<IBondsDataClient>();
            var isin = "RU000A1077V4";
            var bondData = await bondsDataClient.GetBondsQuotes(isin);

            var result = MoexResponseDeserializer.Deserialize(bondData.Securities.Data);
            result.Isin.Should().Be(isin);
        }
    }
}
