using System;
using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.Entities;

public class Transaction
{
    [Key]
    public int ID { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int amount { get; set; }
    public double price { get; set; }
    public DateOnly date { get; set; }
}
