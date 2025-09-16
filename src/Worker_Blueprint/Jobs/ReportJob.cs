using Quartz;
using Worker.Services.Interfaces;

namespace Worker.Jobs
{
    public class ReportJob : IJob
    {
        private readonly ICsvService _iCsvService;
        public static readonly JobKey Key = new JobKey("reportJob");

        public ReportJob(ICsvService iCsvService)
        {
            _iCsvService = iCsvService;
        }

        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }
    }
}
