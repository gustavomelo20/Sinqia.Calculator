using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Sinqia.Calculator.Domain.Repositories;
using Sinqia.Calculator.Infrastructure.DataAccess;
using Sinqia.Calculator.Infrastructure.DataAccess.Repositories;

namespace Sinqia.Calculator.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
        AddFluentMigrator(services, configuration);
    }
    
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SinqiaCalculatorDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ICotacaoReadOnlyRepository, CotacaoRepository>();
    }
    
    private static void AddFluentMigrator(IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentMigratorCore().ConfigureRunner(options =>
        {
            options
                .AddSQLite()
                .WithGlobalConnectionString(configuration.GetConnectionString("DefaultConnection"))
                .ScanIn(Assembly.Load("Sinqia.Calculator.Infrastructure")).For.All();
        });
    }
    
}