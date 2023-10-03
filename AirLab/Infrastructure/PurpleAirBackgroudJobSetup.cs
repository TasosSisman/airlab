using Microsoft.Extensions.Options;
using Quartz;

namespace AirLab.Infrastructure
{
    public class PurpleAirBackgroudJobSetup : IConfigureOptions<QuartzOptions>
    {
        public void Configure(QuartzOptions options)
        {
            var jobKey = JobKey.Create(nameof(PurpleAirBackgroudJob));

            options
                .AddJob<PurpleAirBackgroudJob>(JobBuilder => JobBuilder.WithIdentity(jobKey))
                .AddTrigger(trigger => trigger.ForJob(jobKey)
                    .WithSimpleSchedule(schedule =>
                        schedule.WithIntervalInMinutes(2).RepeatForever()));
        }
    }
}
