using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using StoreBackend.Api.Data;
using StoreBackend.Api.DTOs;
using StoreBackend.Api.Entities;
using StoreBackend.Api.Mapping;

namespace StoreBackend.Api.Endpoints;

public static class ProductTypeEndpoints
{
    const string GetNameEndpointName = "GetProductType";
    public static void MapProductTypeEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("productType").WithParameterValidation();

        group.MapGet("/", (StoreContext dbContext) =>
        {
            var productTypes = dbContext.ProductTypes.Select(type => type.ToProductTypeDTO()).ToList();
            return productTypes;
        });
        
        group.MapGet("/{id}", (int id, StoreContext dbContext) =>
        {
            var product = dbContext.ProductTypes.Where(product => product.ID == id).FirstOrDefault();

            if (product == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(product.ToProductTypeDTO());
        }).WithName(GetNameEndpointName);


        group.MapPost("/", (CreateProductTypeDTO newProductTypeDto, StoreContext dbContext) =>
        {
            ProductType productType = newProductTypeDto.ToProductTypeEntity();

            dbContext.ProductTypes.Add(productType);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetNameEndpointName, new { id = productType.ID }, productType.ToProductTypeDTO());
        });

        group.MapDelete("/{id}", (int id,  StoreContext dbContext )=>
        {
            var elementToRemove = dbContext.ProductTypes.Where(product => product.ID == id).FirstOrDefault();

            if (elementToRemove == null)
            {
                return Results.NotFound();
            }

            dbContext.ProductTypes.Remove(elementToRemove);
            dbContext.SaveChanges();

            return Results.NoContent();
        });
    }
}
