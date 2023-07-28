namespace Devil.Tests.Utils;

[TestClass]
public class ConfigurationUtilsTests
{
    [TestMethod]
    public async Task ValidatidateConfigSetup()
    {
        Assert.IsTrue(!Path.Exists(ConfigurationUtils.DevilConfigurationFolderPath));
        Assert.IsTrue(!File.Exists(ConfigurationUtils.DevilConfigurationFilePath));

        await ConfigurationUtils.SetupFirstRun();

        Assert.IsTrue(Path.Exists(ConfigurationUtils.DevilConfigurationFolderPath));
        Assert.IsTrue(File.Exists(ConfigurationUtils.DevilConfigurationFilePath));
    }



    [TestCleanup] 
    public void Cleanup()
    {
        File.Delete(ConfigurationUtils.DevilConfigurationFilePath);
        Directory.Delete(ConfigurationUtils.DevilConfigurationFolderPath);
    }
}
