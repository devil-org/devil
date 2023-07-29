using Devil.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Devil.Domain
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
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



    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            _ = args[1] switch
            {
                "sqlite" => optionsBuilder.UseSqlite("Data Source=Devil.db", x => x.MigrationsAssembly("Devil.Domain.SqliteMigrations")),

                "mssql" => optionsBuilder.UseSqlServer("Server=localhost;Database=Devil;Trusted_Connection=True;", x => x.MigrationsAssembly("Devil.Domain.MsSqlServerMigrations")),

                "mysql" => optionsBuilder.UseMySql("Server=localhost;Database=Devil;Uid=user;Pwd=password;", MySqlServerVersion.LatestSupportedServerVersion, x => x.MigrationsAssembly("Devil.Domain.MySqlMigrations")),

                "postgres" => optionsBuilder.UseNpgsql("Data Source=localhost;location=Devil;User ID=user;password=password;", x => x.MigrationsAssembly("Devil.Domain.PostgresMigrations")),

                _ => throw new Exception($"Unsupported provider: {args[1]}")
            };

            return new DataContext(optionsBuilder.Options);
        }
    }
}
