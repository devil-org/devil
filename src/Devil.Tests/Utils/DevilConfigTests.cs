using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devil.Tests.Utils;

[TestClass]
public class DevilConfigTests
{
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
