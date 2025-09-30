using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.Entities;

public class Transaction
{
    [Key]
    public int ID { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int Amount { get; set; }
    public double Price { get; set; }
    public DateOnly Date { get; set; }
}