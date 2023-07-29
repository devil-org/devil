using Microsoft.EntityFrameworkCore;

namespace Devil.Domain.Models;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class GroupInventory
{
    public Guid GroupId { get; set; }
    public Group Group { get; set; }
    public Guid InventoryId { get; set; }
    public Inventory Inventory { get; set; }
}

internal static partial class ModelBuilders
{
    internal static void SetGroupInventoryModel(this ModelBuilder mb)
    {
        mb.Entity<GroupInventory>(i =>
        {
            i.ToTable("GroupInventories");
        });
    }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.