using Hangfire;
using NetCoreConsoleAppTemplate.Core.Contracts.Services;
using NetCoreConsoleAppTemplate.Database;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NetCoreConsoleAppTemplate.Services
{
    public class ExampleService : IExampleService
    {
        private readonly ILogger log;
        private readonly ExampleDbContext db;

        public ExampleService(ILogger log, ExampleDbContext db)
        {
            this.log = log;
            this.db = db;
        }

        public void GetExamples()
        {
            log.Information("Starting GetExamples operation.");

            db.Things.AsParallel().ForAll(t =>
            {
                log.Information($"Updating {t.Name}");
                t.Counter++;
            });

            db.SaveChanges();
                
            log.Information("Finished GetExamples operation.");
        }
    }
}
