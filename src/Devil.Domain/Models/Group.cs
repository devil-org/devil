﻿using Microsoft.EntityFrameworkCore;

namespace Devil.Domain.Models;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class Group
{

    public Group() => Id = ObjectExtensions.NewSeqGuid();

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}


internal static partial class ModelBuilders
{
    internal static void SetGroupModel(this ModelBuilder mb)
    {
        mb.Entity<Group>(i =>
        {
            i.ToTable("Groups");
            i.HasKey(i => i.Id);

            i.Property(i => i.Id)
             .IsRequired()
             .ValueGeneratedNever();

            i.Property(i => i.Name)
             .IsRequired()
             .HasMaxLength(200);

            i.Property(i => i.Description)
             .IsRequired(false);
        });
    }
}

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.