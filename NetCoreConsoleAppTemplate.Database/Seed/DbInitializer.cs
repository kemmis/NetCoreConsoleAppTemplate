using Microsoft.EntityFrameworkCore;
using NetCoreConsoleAppTemplate.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreConsoleAppTemplate.Database.Seed
{
    public class DbInitializer : IDbInitializer<ExampleDbContext>
    {
        private readonly ExampleDbContext db;

        public DbInitializer(ExampleDbContext db)
        {
            this.db = db;
        }

        public async Task EnsureSeededAsync()
        {
            if (db.Things.Any())
            {
                return;   // DB has been seeded
            }

            for (var i = 0; i < 5000; i++)
            {
                await db.Things.AddAsync(new Thing
                {
                    Name = $"Thing {i}"
                });
            }

            await db.SaveChangesAsync();
        }
    }

    public interface IDbInitializer<T> where T : DbContext
    {
        Task EnsureSeededAsync();
    }
}
