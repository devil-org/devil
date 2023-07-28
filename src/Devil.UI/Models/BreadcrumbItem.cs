namespace Devil.UI.Models;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class BreadcrumbItem
{
    public string Title { get; set; }
    public string Uri { get; set; }
    public bool Active { get; set; }
}

public static class BreadcrumbUtils
{
    public static readonly IReadOnlyList<BreadcrumbItem> HomeBreadCrumbs = new List<BreadcrumbItem> {
            new BreadcrumbItem { Title = "Home", Uri = "/", Active = true }
        };
}

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.