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
            var transactions = dbContext.Transactions.Include(transaction => transaction.Product).ThenInclude(product => product.ProductType).Select(transaction => transaction.ToTransactionDTO());

            return transactions;
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

            dbContext.Transactions.Add(transaction);
            dbContext.SaveChanges();

            Results.CreatedAtRoute(GetNameEndpointName, new { id = transaction.ID }, transaction.ToTransactionDTO());
        });
    }
}
