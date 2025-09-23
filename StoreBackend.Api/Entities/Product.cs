using System;
using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.Entities;

public class Product
{
    [Key]
    public int ID { get; set; }
    public required string Name { get; set; }
    public int CurrentStock { get; set; }
    public double Price { get; set; }
    public int ProductType { get; set; }
    public ProductType? type { get; set; }
}
