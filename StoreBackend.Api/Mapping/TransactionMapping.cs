using StoreBackend.Api.DTOs;
using StoreBackend.Api.Entities;

namespace StoreBackend.Api.Mapping;

public static class TransactionMapping
{
    public static Transaction ToTransactionEntity(this PurchaseTransactionDTO purchaseDTO)
    {
        Transaction transaction = new()
        {
            ProductId = purchaseDTO.productId,
            Amount = purchaseDTO.amount,
            Price = purchaseDTO.price,
            Date = purchaseDTO.date
        };

        return transaction;
    }

    public static TransactionSummaryDTO ToTransactionDTO(this Transaction purchaseDTO)
    {
        TransactionSummaryDTO transactionDTO = new(
            purchaseDTO.ProductId,
            purchaseDTO.Amount,
            purchaseDTO.Price,
            purchaseDTO.Date
        );

        return transactionDTO;
    }
}
