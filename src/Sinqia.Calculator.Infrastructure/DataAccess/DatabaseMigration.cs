using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Sinqia.Calculator.Infrastructure.DataAccess;

public static class DatabaseMigration
{
    public static void Migrate(IServiceProvider serviceProvider)
    {
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

        runner.ListMigrations();

        runner.MigrateUp();
    }
}