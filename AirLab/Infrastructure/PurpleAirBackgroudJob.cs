using AirLab.Services.PurpleAir;
using Quartz;

namespace AirLab.Infrastructure
{
    [DisallowConcurrentExecution]
    public class PurpleAirBackgroudJob : IJob
    {
        private readonly IPurpleAirService _purpleAirService;

        public PurpleAirBackgroudJob(IPurpleAirService purpleAirService)
        {
            _purpleAirService = purpleAirService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _purpleAirService.GetDataFromPurpleAirAsync();
        }
    }
}
