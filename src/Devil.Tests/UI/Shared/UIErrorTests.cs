using AngleSharp.Dom;
using Bunit;

namespace Devil.Tests.UI.Shared;

/// <summary>
/// The collection of tests to validate the UIError Component.
/// </summary>
[TestClass]
public class UIErrorTests : BaseUITests
{
    /// <summary>
    /// Test to validate that the Errors UI is not visible when not commanded.
    /// </summary>
    [TestMethod]
    public void ValidateNoErrorsMeansNotVisible()
    {
        var cut = RenderComponent<Devil.UI.Shared.UIError>();
        Assert.IsNotNull(cut);

        Assert.IsTrue(cut.Markup == string.Empty);
    }

    /// <summary>
    /// Test to validate that the error UI is visible when commanded.
    /// </summary>
    [TestMethod]
    public void ValidateErrorsUI()
    {
        var cut = RenderComponent<Devil.UI.Shared.UIError>();
        Assert.IsNotNull(cut);


        var errs = new List<string>
            {
                "I am the first error",
                "I am the second error"
            };

        cut.InvokeAsync(() => {
            cut.Instance.SetErrors(errs);
        });

        var headerEle = cut.Find(".card-header");

        var errsEle = cut.FindAll("li");

        Assert.IsFalse(cut.Markup == string.Empty);
        Assert.IsNotNull(headerEle);
        Assert.IsNotNull(errsEle);
        Assert.AreEqual(errs.Count, errsEle.Count);

        Assert.AreEqual("An Error Occurred!", headerEle.InnerHtml.Trim());
        for (int i = 0; i < errsEle.Count; i++)
        {
            var ele = errsEle[i];
            var err = errs.ElementAt(i);

            Assert.AreEqual(err, ele.Text());
        }
    }
}
