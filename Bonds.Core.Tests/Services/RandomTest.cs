using Bonds.Core.Extensions;
using Bonds.Core.Services.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Bonds.Core.Tests.Services
{
    public class RandomTest
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
            var factory = _services.GetRequiredService<IHttpClientFactory>();

            var client = factory.CreateClient();

            var c = await client.GetAsync(new Uri("https://www.tinkoff.ru/invest/bonds/RU000A108AK6"));
        }

        [Test]
        public async Task GetAllBondsTest()
        {
            var service = _services.GetRequiredService<IMoexHttpDataClient>();

            var response = await service.GetAllBonds();


        }
    }
}