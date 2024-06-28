using System.Diagnostics;
using Bonds.App.Api.Extensions;
using Bonds.Core.Extensions;
using Bonds.Core.Services;
using Bonds.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bonds.Core.Tests.Services
{
    public class TcsServiceTests
    {
        private ITcsService _service;

        [SetUp]
        public void SetUp()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            _service = new ServiceCollection()
                .AddCoreServices()
                .AddTinkoff(config)
                .AddApplicationOptions(config)
                .BuildServiceProvider()
                .GetRequiredService<ITcsService>();
        }

        [Test]
        public async Task GetAllIsinsTest()
        {
            var c = await _service.GetAllIsins();
        }

        [Test]
        public async Task GetCandlesTest()
        {
            var sw = Stopwatch.StartNew();
            var c = await _service.GetProcessedBondsCandles();

        }
    }
}
