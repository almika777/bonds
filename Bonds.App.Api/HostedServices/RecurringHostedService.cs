using Bonds.Core.Jobs;

namespace Bonds.App.Api.HostedServices
{
    public class RecurringHostedService : IHostedService
    {
        private readonly MoexTradesReader _reader;
        private readonly IConfiguration _config;
        private readonly ILogger<RecurringHostedService> _logger;

        private TimeSpan Delay => TimeSpan.FromMinutes(int.Parse(_config["JobDelayMinutes"]));

        public RecurringHostedService(MoexTradesReader reader, IConfiguration config, ILogger<RecurringHostedService> logger)
        {
            _reader = reader;
            _config = config;
            
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start");
            Work(cancellationToken);
            return Task.CompletedTask;
        }

        private async Task Work(CancellationToken cancellationToken)
        {
            while (true)
            {
                _logger.LogInformation($"Run new iteration {DateTime.Now}");

                await _reader.Read();
                await Task.Delay(Delay, cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
