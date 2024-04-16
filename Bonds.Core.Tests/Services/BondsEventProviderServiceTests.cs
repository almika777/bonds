using Bonds.Core.Services.Interfaces;
using FluentAssertions.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bonds.Core.Extensions;
using Bonds.Core.Services;

namespace Bonds.Core.Tests.Services
{
    public class BondsEventProviderServiceTests
    {
        private ServiceProvider _services;

        [SetUp]
        public void Setup()
        {
            _services = new ServiceCollection().AddCoreServices(null).BuildServiceProvider();
        }

        [Test]
        public async Task GetBondsTradesTest()
        {
            var service = (BondsEventProviderService)_services.GetRequiredService<IBondsEventProviderService>();

            var response = await service.GetBondsBuySellVolumes("RU000A106Q47");


        }
    }
}
