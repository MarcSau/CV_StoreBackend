using Microsoft.EntityFrameworkCore;
using StoreBackend.Api.Entities;
namespace StoreBackend.Api.Data;

public class StoreContext(DbContextOptions<StoreContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductType> ProductTypes => Set<ProductType>();
    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductType>().HasData(
            new { ID = 1, Name = "Boardgame" },
            new { ID = 2, Name = "Book" },
            new { ID = 3, Name = "Videogame" },
            new { ID = 4, Name = "Software" },
            new { ID = 5, Name = "Hardware" },
            new { ID = 6, Name = "Other" }
        );

        modelBuilder.Entity<Product>().HasData(
            new {ID = 1, Name = "DnD 2025 Rulebook", CurrentStock = 25, Price = 29.99, productTypeId = 2},
            new {ID = 2, Name = "Monopoly", CurrentStock = 25, Price = 19.99, productTypeId = 1},
            new {ID = 3, Name = "Grand Theft Auto 6", CurrentStock = 25, Price = 79.99, productTypeId = 3}
        );
    
    }
}
