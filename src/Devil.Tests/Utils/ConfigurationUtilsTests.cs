namespace Devil.Tests.Utils;

/// <summary>
/// This is a Collection of test to validate the intended operations happen within <seealso cref="Devil.ConfigurationUtils"/>
/// </summary>
[TestClass]
public class ConfigurationUtilsTests
{
    /// <summary>
    /// This test validates that a brand new folder and config file will be generated when devil first starts up on a system on first run.
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task ValidatidateConfigSetup()
    {
        Assert.IsTrue(!Path.Exists(ConfigurationUtils.DevilConfigurationFolderPath));
        Assert.IsTrue(!File.Exists(ConfigurationUtils.DevilConfigurationFilePath));

        await ConfigurationUtils.SetupFirstRun();

        Assert.IsTrue(Path.Exists(ConfigurationUtils.DevilConfigurationFolderPath));
        Assert.IsTrue(File.Exists(ConfigurationUtils.DevilConfigurationFilePath));
    }


    /// <summary>
    /// This Cleans up all the Test data.
    /// </summary>
    [TestCleanup] 
    public void Cleanup()
    {
        File.Delete(ConfigurationUtils.DevilConfigurationFilePath);
        Directory.Delete(ConfigurationUtils.DevilConfigurationFolderPath);
    }
}
