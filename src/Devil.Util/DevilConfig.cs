namespace Devil;

/// <summary>
/// This holds the Configuration that was gathered at Startup
/// </summary>
public sealed class DevilConfig
{
    /// <summary>
    /// The Type of Database to use.  Applicable values are sqlite, mysql, mssql, postgres
    /// </summary>
    public string DatabaseType { get; private set; } = "sqlite";

    /// <summary>
    /// The Connection string to use for the connection.
    /// </summary>
    public string DatabaseConnection { get; set; } = $"Data Source={ConfigurationUtils.DevilConfigurationFolderPath}\\.devil\\devil.db";
}
