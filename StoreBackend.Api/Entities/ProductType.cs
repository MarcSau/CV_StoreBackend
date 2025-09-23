using System;
using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.Entities;

public class ProductType
{
    [Key]
    public int Id { get; set; }

    public required string Name { get; set; }
}
