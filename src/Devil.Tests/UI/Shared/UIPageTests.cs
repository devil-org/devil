using AngleSharp.Dom;
using Bunit;
using Devil.UI.Models;

namespace Devil.Tests.UI.Shared;

/// <summary>
/// The collection of tests to validate the UIPage Component.
/// </summary>
[TestClass]
public class UIPageTests : BaseUITests
{
    /// <summary>
    /// Test to validate that the Base spinner shows and then is removed when commanded.
    /// </summary>
    [TestMethod]
    public void ValidateSpinerLogic()
    {
        var childUI = "<p id='testUI'>Hello World</p>";
        var cut = RenderComponent<Devil.UI.Shared.UIPage>(parameters => parameters
        .Add(p => p.Title, "")
        .Add(p => p.Breadcrumbs, BreadcrumbUtils.HomeBreadCrumbs)
        .AddChildContent(childUI)
        );

        Assert.IsNotNull(cut);
        Assert.IsNotNull(cut.Find(".sk-wave.sk-center"));

        cut.InvokeAsync(() =>
        {
            cut.Instance.SetLoading(false);
        });
        Assert.AreEqual(0, cut.FindAll(".sk-wave.sk-center").Count);
        Assert.IsNotNull(cut.Find("#testUI"));
    }

    /// <summary>
    /// Test to validate that the Errors section is visible when commanded.
    /// </summary>
    [TestMethod]
    public void ValidateErrorLogic()
    {
        var childUI = "<p id='testUI'>Hello World</p>";
        var cut = RenderComponent<Devil.UI.Shared.UIPage>(parameters => parameters
        .Add(p => p.Title, "")
        .Add(p => p.Breadcrumbs, BreadcrumbUtils.HomeBreadCrumbs)
        .AddChildContent(childUI)
        );

        var errs = new List<string>
            {
                "I am the first error",
                "I am the second error"
            };

        cut.InvokeAsync(() =>
        {
            cut.Instance.SetLoading(false);
            cut.Instance.SetErrors(errs);                
        });

        Assert.AreEqual(0, cut.FindAll(".sk-wave.sk-center").Count);
        Assert.AreEqual(0, cut.FindAll("#testUI").Count);

        var headerEle = cut.Find(".card-header");

        var errsEle = cut.FindAll(".error-item");

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
