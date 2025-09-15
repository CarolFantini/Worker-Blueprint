using Worker.Services.Interfaces;

namespace Worker.Services
{
    public class CsvService : ICsvService
    {
        private readonly ILogger<CsvService> _logger;

        public CsvService(ILogger<CsvService> logger)
        {
            _logger = logger;
        }

        public async Task GenerateCsv(string csvFilePath)
        {
            await Task.Run(() =>
            {
                // Placeholder for CSV generation logic.
                _logger.LogInformation($"CSV file would be generated at: {csvFilePath}");
            });
        }
    }
}
