using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreConsoleAppTemplate.Core.Contracts.Services
{
    public interface IExampleHangfireJobManagementService
    {
        void ScheduleRecurringJobs();
    }
}
