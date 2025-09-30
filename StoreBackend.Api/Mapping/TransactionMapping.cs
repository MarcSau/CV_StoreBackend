using StoreBackend.Api.DTOs;
using StoreBackend.Api.Entities;

namespace StoreBackend.Api.Mapping;

public static class TransactionMapping
{

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

    public static Transaction ToTransactionEntity(this PurchaseTransactionDTO purchaseDTO)
    {
        return new Transaction()
        {
            ProductId = purchaseDTO.productId,
            Amount = purchaseDTO.amount,
            Price = purchaseDTO.price,
            Date = purchaseDTO.date
        };
    }
}