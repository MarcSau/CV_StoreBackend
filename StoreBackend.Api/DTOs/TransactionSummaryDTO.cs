namespace StoreBackend.Api.DTOs;

public record class TransactionSummaryDTO
(
    int productId,
    int amount,
    double price,
    DateOnly date
);