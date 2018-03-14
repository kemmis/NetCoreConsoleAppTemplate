using Microsoft.EntityFrameworkCore;
using NetCoreConsoleAppTemplate.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreConsoleAppTemplate.Database
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions options) : base(options) { }
        public ExampleDbContext() : base() { }

        public DbSet<Thing> Things { get; set; }
    }
}
