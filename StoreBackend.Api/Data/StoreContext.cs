using Microsoft.EntityFrameworkCore;
using StoreBackend.Api.Entities;
namespace StoreBackend.Api.Data;

public class StoreContext(DbContextOptions<StoreContext> options) : DbContext(options)
{
    DbSet<Product> Products => Set<Product>();
    DbSet<ProductType> ProductTypes => Set<ProductType>();
    DbSet<Transaction> Transactions => Set<Transaction>();

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
            new {ID = 1, Name = "DnD 2025 Rulebook", CurrentStock = 25, Price = 29.99, ProductType = 2}
        );
        
    }
}
