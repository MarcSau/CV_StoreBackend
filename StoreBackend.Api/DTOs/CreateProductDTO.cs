using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.DTOs;

public record class CreateProductDTO
(
    [Required][StringLength(20)] string name,
    [Required] int initialStock,
    [Required] decimal price,
    [Required] int productType
);
