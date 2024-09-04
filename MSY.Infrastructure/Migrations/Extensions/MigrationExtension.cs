using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MSY.Infrastructure.Migrations.Extensions;

public static class MigrationExtension
{
    public static void ConfigureMigrator(this IServiceCollection services, IConfiguration configuration)
    {
        var connString = configuration.GetSection("DatabaseConnectionOptions:ConnectionString")
            .Get<string>();
        services.AddFluentMigratorCore()
            .ConfigureRunner(
                rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(connString)
                    .ScanIn(typeof(MigrationExtension).Assembly)
                    .For.Migrations());
    }
    public static IApplicationBuilder Migrate(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var runner = scope.ServiceProvider.GetService<IMigrationRunner>();
        runner.ListMigrations();
        runner.MigrateUp();
        return app;
    }
}