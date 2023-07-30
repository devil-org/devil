using Bunit;
using Devil.Domain;
using Devil.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Devil.Tests.UI;

/// <summary>
/// The Base tests to do UI validation
/// </summary>
public abstract class BaseUITests : Bunit.TestContext
{
    [TestInitialize]
    public async Task Init()
    {
        JSInterop.Mode = JSRuntimeMode.Loose;
        Services.SetupDevilDomain("sqlite", "Data Source=devil-tests.db");
        Services.SetupDevilUI();
        using var scope = Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DataContext>();
        await db.Database.EnsureDeletedAsync();
        await db.Database.MigrateAsync();
    }
}
