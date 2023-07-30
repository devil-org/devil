using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Devil.Domain;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Extension Method to setup all the Devil.Domain Dependencies.
    /// </summary>
    /// <param name="services">The Service Collection for DI.</param>
    /// <param name="config">The configuration.</param>
    /// <returns></returns>
    public static IServiceCollection SetupDevilDomain(this IServiceCollection services, IConfiguration config)
    {
        var provider = config.GetValue("DatabaseType", "sqlite")!.ToLower();
        return SetupDevilDomainInternal(services, provider, config.GetValue<string>("DatabaseConnection")!);
    }

    /// <summary>
    /// Extension Method to setup all the Devil.Domain Dependencies.
    /// </summary>
    /// <param name="services">The Service Collection for DI.</param>
    /// <param name="provider">The provider to use</param>
    /// <param name="connectionString">The ConnectionString to use for the database.</param>
    /// <returns></returns>
    public static IServiceCollection SetupDevilDomain(this IServiceCollection services, string provider, string connectionString)
     => SetupDevilDomainInternal(services, provider, connectionString);



    static IServiceCollection SetupDevilDomainInternal(IServiceCollection services, string provider, string connString)
    {
        services.AddDbContext<DataContext>(
                    options => _ = provider switch
                    {
                        "sqlite" => options.UseSqlite(
                            connString,
                            x => x.MigrationsAssembly("Devil.Domain.SqliteMigrations")),

                        "mssql" => options.UseSqlServer(
                            connString,
                            x => x.MigrationsAssembly("Devil.Domain.MsSqlServerMigrations")),

                        "mysql" => options.UseSqlServer(
                            connString,
                            x => x.MigrationsAssembly("Devil.Domain.MySqlMigrations")),

                        "postgres" => options.UseSqlServer(
                            connString,
                            x => x.MigrationsAssembly("Devil.Domain.PostgresMigrations")),

                        _ => throw new Exception($"Unsupported provider: {provider}")
                    });

        return services;
    }
}
