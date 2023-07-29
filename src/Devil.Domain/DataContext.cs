using Devil.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Devil.Domain
{
    public class DataContext : DbContext
    {
        protected DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SetInventoryModel();
            modelBuilder.SetGroupModel();
            modelBuilder.SetGroupInventoryModel();
        }
    }
}
