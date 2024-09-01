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
            _services = new ServiceCollection().AddCoreServices().BuildServiceProvider();
        }


        [Test]
        public async Task Deserialize1Test()
        {
            var bondsDataClient = _services.GetRequiredService<IMoexHttpDataClient>();
            var isin = "RU000A1077V4";

        }
        //TODO Написать нормальные тесты
        [Test]
        [TestCase("RU000A1077V4", 536)]
        [TestCase("RU000A0NTYB5", 269)]
        [TestCase("RU000A0NTYB9", null)]
        public async Task should_GetBondEmitterId_parse(string isin, long? emitterId)
        {
            var bondsDataClient = _services.GetRequiredService<IMoexHttpDataClient>();
            var res = await bondsDataClient.GetBondEmitterId(isin);

            res.EmmiterId.Should().Be(emitterId);
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
