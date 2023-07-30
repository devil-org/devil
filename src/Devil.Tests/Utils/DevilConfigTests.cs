namespace Devil.Tests.Utils;

/// <summary>
/// This is a Collection of tests to validate the Configuration that is loaded from <see cref="Devil.ConfigurationUtils.DevilConfigurationFilePath"/>
/// </summary>
[TestClass]
public class DevilConfigTests
{
    /// <summary>
    /// This test validates all the defaults when a brand new DevilConfig is generated.
    /// </summary>
    [TestMethod]
    public void NewDevilConfigTest()
    {
        var config = new DevilConfig();

        Assert.IsNotNull(config);
        Assert.IsNotNull(config.DatabaseType);
        Assert.AreEqual("sqlite", config.DatabaseType);

        Assert.IsNotNull(config.DatabaseConnection);
        Assert.AreEqual($"Data Source={ConfigurationUtils.DevilConfigurationFolderPath}\\devil.db", config.DatabaseConnection);
    }
}
