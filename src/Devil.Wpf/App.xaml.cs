using Devil.Domain;
using Devil.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Windows;

namespace Devil.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
[ExcludeFromCodeCoverage]
public partial class App : Application
{
    public static IHost? Host { get; private set; }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await ConfigurationUtils.SetupFirstRun();
        var appLocation = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location);

        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(e.Args)
            .ConfigureAppConfiguration(c =>
            {
                c.SetBasePath(appLocation!);
                c.AddJsonFile(ConfigurationUtils.DevilConfigurationFilePath);
            })
            .ConfigureServices(ConfigureServices)
            .Build();


        using var scope = Host.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DataContext>();

        if (db.Database.GetPendingMigrations().Any())
            db.Database.Migrate();
    }

    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddWpfBlazorWebView();
        services.AddBlazorWebViewDeveloperTools();
        services.SetupDevilDomain(context.Configuration);
        services.SetupDevilUI();
    }
}
