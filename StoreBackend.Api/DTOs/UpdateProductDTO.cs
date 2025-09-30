using System.ComponentModel.DataAnnotations;
namespace StoreBackend.Api.DTOs;

public record class UpdateProductDTO
(
    [Required] int id,
    [Required] string name,
    [Required] double price,
    [Required] int currentStock,
    [Required] int productType
);