using Bunit;

namespace Devil.Tests.UI.Shared;

/// <summary>
/// The collection of tests to validate the MainLayout Component.
/// </summary>
[TestClass]
public class MainLayoutTests : BaseUITests
{
    /// <summary>
    /// Test to validate that the html is generated correctly.
    /// </summary>
    [TestMethod]
    public void ValidateMainLayoutLoad()
    {
        var cut = RenderComponent<Devil.UI.Shared.MainLayout>();
        Assert.IsNotNull(cut);

        Assert.IsNotNull(cut.Find(".page"));
        Assert.IsNotNull(cut.Find("article.content"));
    }
}
