using System.Text.Json;

namespace Devil;

/// <summary>
/// This is a utilities class to hold methods and properties that are applicable to the configuration
/// </summary>
public static class ConfigurationUtils
{
    /// <summary>
    /// The folder path where the Configuration lives.
    /// </summary>
    public readonly static string DevilConfigurationFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".devil");

    /// <summary>
    /// The file path where the Configuration file lives
    /// </summary>
    public readonly static string DevilConfigurationFilePath = Path.Combine(DevilConfigurationFolderPath, "devilsettings.json");

    /// <summary>
    /// Method to create the folder and file structure on devils first run on the machine.
    /// </summary>
    public static async Task SetupFirstRun()
    {
        if (!Directory.Exists(DevilConfigurationFolderPath))
        {
            Directory.CreateDirectory(DevilConfigurationFolderPath);
        }

        if(!File.Exists(DevilConfigurationFilePath))
        {
            using var sw = new FileStream(DevilConfigurationFilePath, FileMode.Create, FileAccess.Write);
            await JsonSerializer.SerializeAsync(sw, new DevilConfig());
        }
    }
}
