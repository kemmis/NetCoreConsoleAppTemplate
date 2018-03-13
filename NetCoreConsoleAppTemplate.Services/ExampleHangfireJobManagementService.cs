using Hangfire;
using NetCoreConsoleAppTemplate.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreConsoleAppTemplate.Services
{
    public class ExampleHangfireJobManagementService : IExampleHangfireJobManagementService
    {
        public void ScheduleRecurringJobs()
        {
            // this should clear out any queued/missed instances of this job
            RecurringJob.RemoveIfExists("ExampleHangfireJob");

            // add the ExampleHangfireJob to run every 5 minutes
            RecurringJob.AddOrUpdate<ExampleHangfireJob>("ExampleHangfireJob", x => x.Run(null), Cron.MinuteInterval(1));
        }
    }
}
