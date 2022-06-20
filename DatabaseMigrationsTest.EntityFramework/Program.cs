using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DatabaseMigrationsTest.EntityFramework
{
    class Program : IDesignTimeDbContextFactory<PersonDbContext>
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            using (var sc = p.CreateDbContext(null))
            {
                sc.Database.Migrate();

                sc.SaveChanges();
            }
        }

        public PersonDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PersonDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Database"));

            return new PersonDbContext(optionsBuilder.Options);
        }
    }
}
