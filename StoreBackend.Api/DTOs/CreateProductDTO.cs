using System.ComponentModel.DataAnnotations;
namespace StoreBackend.Api.DTOs;

public record class CreateProductDTO
(
    [Required][StringLength(35)] string name,
    [Required] int initialStock,
    [Required] double price,
    [Required] int productType
);