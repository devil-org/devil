using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Devil.Domain;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Extension Method to setup all the Devil.UI Dependencies.
    /// </summary>
    /// <param name="services">The Service Collection for DI.</param>
    /// <param name="config">The configuration.</param>
    /// <returns></returns>
    public static IServiceCollection SetupDevilDomain(this IServiceCollection services, IConfiguration config)
    {
        var provider = config.GetValue("DatabaseType", "sqlite")!.ToLower();

        services.AddDbContext<DataContext>(
                    options => _ = provider switch
                    {
                        "sqlite" => options.UseSqlite(
                            config.GetValue<string>("DatabaseConnection"),
                            x => x.MigrationsAssembly("Devil.Domain.SqliteMigrations")),

                        "mssql" => options.UseSqlServer(
                            config.GetValue<string>("DatabaseConnection"),
                            x => x.MigrationsAssembly("Devil.Domain.MsSqlServerMigrations")),

                        "mysql" => options.UseSqlServer(
                            config.GetValue<string>("DatabaseConnection"),
                            x => x.MigrationsAssembly("Devil.Domain.MySqlMigrations")),

                        "postgres" => options.UseSqlServer(
                            config.GetValue<string>("DatabaseConnection"),
                            x => x.MigrationsAssembly("Devil.Domain.PostgresMigrations")),

                        _ => throw new Exception($"Unsupported provider: {provider}")
                    });

        return services;
    }
}
