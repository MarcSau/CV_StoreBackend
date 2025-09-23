using System;
using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.Entities;

public class Product
{
    [Key]
    public int ID { get; set; }

    [Required][StringLength(20)]
    public string Name { get; set; }

    public int CurrentStock { get; set; }
    public double Price { get; set; }
}
