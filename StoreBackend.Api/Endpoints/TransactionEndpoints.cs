using Microsoft.EntityFrameworkCore;
using StoreBackend.Api.Data;
using StoreBackend.Api.DTOs;
using StoreBackend.Api.Entities;
using StoreBackend.Api.Mapping;

namespace StoreBackend.Api.Endpoints;

public static class TransactionEndpoints
{
    public const string GetNameEndpointName = "GetTransaction";
    public static void MapTransactionEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("transaction").WithParameterValidation();

        group.MapGet("/", (StoreContext dbContext) =>
        {
            var transactions = dbContext.Transactions.Include(transaction => transaction.Product).ThenInclude(product => product.ProductType).Select(transaction => transaction.ToTransactionDTO()).ToList();

            return Results.Ok(transactions);
        });

        group.MapGet("/{id}", (int id, StoreContext dbContext) =>
        {
            var transaction = dbContext.Transactions.Include(transaction => transaction.Product).ThenInclude(product => product.ProductType).Where(transaction => transaction.ID == id).FirstOrDefault();

            if (transaction == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(transaction.ToTransactionDTO());
        }).WithName(GetNameEndpointName);

        group.MapPost("/", (PurchaseTransactionDTO purchase, StoreContext dbContext) =>
        {
            Transaction transaction = purchase.ToTransactionEntity();

            var purchasedProduct = dbContext.Products.Where(product => product.ID == purchase.productId).FirstOrDefault();

            if (purchasedProduct == null)
            {
                return Results.NotFound();
            }

            if (purchasedProduct.CurrentStock < transaction.Amount)
            {
                return Results.BadRequest("Not enough stock available");
            }

            dbContext.Transactions.Add(transaction);
            purchasedProduct.CurrentStock -= purchase.amount;
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetNameEndpointName, new { id = transaction.ID }, transaction.ToTransactionDTO());
        });
    }
}