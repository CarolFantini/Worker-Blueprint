using Worker.Services.Interfaces;

namespace Worker_Blueprint
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICsvService _csvService;

        public Worker(ILogger<Worker> logger, ICsvService csvService)
        {
            _logger = logger;
            _csvService = csvService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _csvService.GenerateCsv("FILE_PATH");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
