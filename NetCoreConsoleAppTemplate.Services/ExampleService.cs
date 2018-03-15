using Hangfire;
using NetCoreConsoleAppTemplate.Core.Contracts.Services;
using NetCoreConsoleAppTemplate.Database;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public void GetExamples(CancellationToken cancellationToken)
        {
            var things = db.Things.ToList();
            var po = new ParallelOptions
            {
                CancellationToken = cancellationToken,
                MaxDegreeOfParallelism = System.Environment.ProcessorCount
            };

            try
            {
                Parallel.ForEach(things, po, t =>
                 {
                     po.CancellationToken.ThrowIfCancellationRequested();
                     log.Information($"Updating {t.Name}");
                     t.Counter++;
                 });
            }
            catch (OperationCanceledException ex)
            {
                log.Information("Stopping GetExamples() due to shutdown.");
                return;
            }

            db.SaveChanges();

            log.Information("Finished GetExamples operation.");
        }
    }
}
