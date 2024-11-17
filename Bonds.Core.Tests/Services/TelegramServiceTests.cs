using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bonds.Core.Extensions;
using Bonds.Core.Services.Interfaces;
using Bonds.Telegram.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Bonds.Core.Tests.Services
{
    public class TelegramServiceTests
    {
        private ITelegramService _service;

        [SetUp]
        public void SetUp()
        {
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new List<KeyValuePair<string, string?>>()
                {
                    new("TelegramBotToken", "6955275069:AAGVKlUmTCvO_9hmYQHfVAI5Hj8yJzX_d3M")
                }).Build();

            _service = new ServiceCollection()
                .AddCoreServices()
                .AddTelegram(config)
                .BuildServiceProvider()
                .GetRequiredService<ITelegramService>();
        }

        [Test]
        public async Task SendMessageTest()
        {
            await _service.SendMessage("285783010", "test");
        }
    }
}
