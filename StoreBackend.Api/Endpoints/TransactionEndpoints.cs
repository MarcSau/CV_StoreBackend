using System;
using Microsoft.EntityFrameworkCore;
using StoreBackend.Api.Data;

namespace StoreBackend.Api.Endpoints;

public static class TransactionEndpoints
{
    public static void MapTransactionEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("transaction").WithParameterValidation();

        group.MapGet("/", (StoreContext dbContext) =>
        {
            var transactions = dbContext.Transactions.Include(transaction => transaction.Product).ThenInclude(product => product.ProductType);

            return transactions;
        });
        
        group.MapPost("/", (StoreContext dbContext) =>
        {
            var transactions = dbContext.Transactions.Include(transaction => transaction.Product).ThenInclude(product => product.ProductType);

            return transactions;
        });
    }
}
