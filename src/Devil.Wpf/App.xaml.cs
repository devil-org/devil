using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Windows;
using Devil.UI;

namespace Devil.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IHost? Host { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        var appLocation = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location);

        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(e.Args)
            .ConfigureAppConfiguration(c =>
            {
                c.SetBasePath(appLocation!);
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
        services.AddWpfBlazorWebView();
        services.AddBlazorWebViewDeveloperTools();
        services.SetupDevilUI();
    }
}
