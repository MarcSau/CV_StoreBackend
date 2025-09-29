using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.DTOs;

public record class ProductSummaryDTO
(
    [Required] int id,
    [Required] string name,
    [Required] double price,
    [Required] int currentStock,
    int productTypeId,
    string productType
);
