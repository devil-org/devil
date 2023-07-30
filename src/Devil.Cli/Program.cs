using Devil;
using Devil.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

await ConfigurationUtils.SetupFirstRun();

using IHost _host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((h, conf) => {
        conf.AddJsonFile(ConfigurationUtils.DevilConfigurationFilePath);
    })
    .ConfigureServices((h, s) =>
    {
        s.SetupDevilDomain(h.Configuration);
    }).Build();