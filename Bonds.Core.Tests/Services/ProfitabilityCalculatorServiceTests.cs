using Bonds.Core.Dto;
using Bonds.Core.Enums;
using Bonds.Core.Extensions;
using Bonds.Core.Results;
using Bonds.Core.Services.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Bonds.Core.Tests.Services
{
    public class ProfitabilityCalculatorServiceTests
    {
        private ServiceProvider _services;

        [SetUp]
        public void Setup()
        {
            _services = new ServiceCollection().AddCoreServices().BuildServiceProvider();
        }

        [Test]
        public async Task GetNkdTest()
        {
            var service = _services.GetRequiredService<IProfitabilityCalculatorService>();

            var result = service.GetNkd(new BondInfo
            {
                IssueDate = new DateTime(2023, 11, 16),
                CouponDate = new DateTime(2024, 02, 15),
                CouponPercent = 17,
                CouponValue = 42.38,
                FaceValue = 1000,
                CouponFrequency = 4
            });
            result.Should().Be(10.71);
        }

        [Test]
        [TestCase("RU000A1077V4")]
        public async Task GetSimpleProfitTest(string isin)
        {
            var service = _services.GetRequiredService<IProfitabilityCalculatorService>();

            var result = await service.Calculate(new ProfitabilityDto
            {
                Isin = isin,
                PriceOfPurchase = 1000,
                DateOfPurchase = DateTime.Now,
                ProfitabilityType = ProfitabilityType.Simple
            });
            result.Should().Be(10.71);
        }
    }
}