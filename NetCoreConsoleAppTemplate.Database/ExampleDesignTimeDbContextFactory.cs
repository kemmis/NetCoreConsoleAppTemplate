using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreConsoleAppTemplate.Database
{
    public class ExampleDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ExampleDbContext>
    {
        public ExampleDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ExampleDbContext>();
            builder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ExampleApp;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new ExampleDbContext(builder.Options);
        }
    }
}
