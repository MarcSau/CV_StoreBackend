using System;
using Microsoft.EntityFrameworkCore;
using StoreBackend.Api.Data;
using StoreBackend.Api.DTOs;
using StoreBackend.Api.Entities;
using StoreBackend.Api.Mapping;
namespace StoreBackend.Api.Endpoints;

public static class ProductEndpoints
{
    const string GetNameEndpointName = "GetProduct";

    public static void MapProductEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("product").WithParameterValidation();

        group.MapPost("/", (CreateProductDTO newProductDto, StoreContext dbContext) =>
        {
            Product product = newProductDto.ToProductEntity();

            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            dbContext.Products.Entry(product).Reference(p => p.ProductType).Load();

            return Results.CreatedAtRoute(GetNameEndpointName, new { id = product.ID }, product.ToProductDTO());
        });

        group.MapGet("/{id}", (int id, StoreContext dbContext) =>
        {
            var product = dbContext.Products.Include(product => product.ProductType).Where(product => product.ID == id).FirstOrDefault();

            if (product == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(product.ToProductDTO());
        }).WithName(GetNameEndpointName);
    }
}
