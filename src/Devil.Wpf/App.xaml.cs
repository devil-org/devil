using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Windows;
using Devil.UI;
using System.Configuration;

namespace Devil.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
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


        //using var scope = Host.Services.CreateScope();
        //var db = scope.ServiceProvider.GetRequiredService<DataContext>();

        //if (db.Database.GetPendingMigrations().Any())
        //    db.Database.Migrate();
    }

    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        var provider = context.Configuration.GetValue("Provider", "SqlServer");


        services.AddWpfBlazorWebView();
        services.AddBlazorWebViewDeveloperTools();
        services.SetupDevilUI();
    }
}
