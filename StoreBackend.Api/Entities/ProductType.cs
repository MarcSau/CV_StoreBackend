using System;
using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.Entities;

public class ProductType
{
    [Key]
    public int ID { get; set; }
    public required string Name { get; set; }
}
