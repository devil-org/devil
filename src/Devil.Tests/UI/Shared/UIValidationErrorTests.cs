using AngleSharp.Dom;
using Bunit;

namespace Devil.Tests.UI.Shared;

/// <summary>
/// The collection of tests to validate the UIValidation Component.
/// </summary>
[TestClass]
public class UIValidationErrorTests : BaseUITests
{
    /// <summary>
    /// Test to validate when there are no errors passed, that its not visible.
    /// </summary>
    [TestMethod]
    public void ValidateNoErrorsMeansNotVisible()
    {
        var cut = RenderComponent<Devil.UI.Shared.UIValidationError>();
        Assert.IsNotNull(cut);

        Assert.IsTrue(cut.Markup == string.Empty);
    }

    /// <summary>
    /// Test to validate when errors are passed, the UI is rendered and rendered correctly.
    /// </summary>
    [TestMethod]
    public void ValidateUIValidationError()
    {
        var cut = RenderComponent<Devil.UI.Shared.UIValidationError>();
        Assert.IsNotNull(cut);


        var errs = new List<string>
            {
                "I am the first error",
                "I am the second error"
            };

        cut.InvokeAsync(() => {
            cut.Instance.SetErrors(errs);
        });

        var headerEle = cut.Find("h4");

        var errsEle = cut.FindAll("li");

        Assert.IsFalse(cut.Markup == string.Empty);
        Assert.IsNotNull(headerEle);
        Assert.IsNotNull(errsEle);
        Assert.AreEqual(errs.Count, errsEle.Count);

        Assert.AreEqual("Validation Errors", headerEle.InnerHtml.Trim());
        for (int i = 0; i < errsEle.Count; i++)
        {
            var ele = errsEle[i];
            var err = errs.ElementAt(i);

            Assert.AreEqual(err, ele.Text());
        }
    }
}
