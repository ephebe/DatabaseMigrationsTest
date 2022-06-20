using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DatabaseMigrationsTest.FluentMigrator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateDefaultBuilder().Build();

            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            var runner = provider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();

            await host.StopAsync();
        }

        static IHostBuilder CreateDefaultBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(app =>
                {
                    app.SetBasePath(AppContext.BaseDirectory);
                    app.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((context,services) =>
                {
                    services
                        .AddFluentMigratorCore()
                        .ConfigureRunner(rb => rb
                            .AddSqlServer()
                            .WithGlobalConnectionString(context.Configuration.GetConnectionString("Database"))
                            .ScanIn(typeof(Program).Assembly).For.Migrations())
                        .AddLogging(lb => lb.AddFluentMigratorConsole());
                });
        }
    }
}
