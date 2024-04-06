using System.Globalization;
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
            _services = new ServiceCollection().AddCoreServices(null).BuildServiceProvider();
        }

        [Test]
        public async Task DeserializeTest()
        {
            var bondsDataClient = _services.GetRequiredService<IMoexHttpDataClient>();
            var isin = "RU000A1077V4";
            var bondData = await bondsDataClient.GetBondsInfo(isin);

        }


        [Test]
        public async Task Deserialize1Test()
        {
            var bondsDataClient = _services.GetRequiredService<IMoexHttpDataClient>();
            var isin = "RU000A1077V4";

        }

        [Test]
        public async Task Deserialize2Test()
        {
            var bondsDataClient = _services.GetRequiredService<IMoexHttpDataClient>();
            var c1 = await bondsDataClient.GetBondsTrades("RU000A107P62");
           // MoexResponseDeserializer.Deserialize(c);
        }
    }
}
