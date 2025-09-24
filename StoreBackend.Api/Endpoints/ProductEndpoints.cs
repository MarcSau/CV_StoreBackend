using System;
using Microsoft.EntityFrameworkCore;
using StoreBackend.Api.Data;
using StoreBackend.Api.DTOs;
using StoreBackend.Api.Mapping;
namespace StoreBackend.Api.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("product").WithParameterValidation();

        group.MapPut("/", (CreateProductDTO newProduct, StoreContext dbContext) =>
        {

        });

        group.MapGet("/", (int id, StoreContext dbContext) =>
        {
            var product = dbContext.Products.Find(id);
            if (product == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(product.ToProductDTO());
        });
    }
}
