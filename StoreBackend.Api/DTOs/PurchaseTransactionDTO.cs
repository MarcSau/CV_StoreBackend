using System.ComponentModel.DataAnnotations;
namespace StoreBackend.Api.DTOs;

public record class PurchaseTransactionDTO
(
    [Required] int productId,
    [Required] int amount,
    [Required] double price,
    [Required] DateOnly date
);