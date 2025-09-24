using System;
using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.Entities;

public class Transaction
{
    [Key]
    public int ID { get; set; }
    public int productID { get; set; }
    public Product? Product { get; set; }
    public int amount;
    public double price;
}
