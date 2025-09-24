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

        group.MapPost("/", (CreateProductTypeDTO newProductTypeDto, StoreContext dbContext) =>
        {
            ProductType productType = newProductTypeDto.ToProductTypeEntity();

            dbContext.ProductTypes.Add(productType);
            dbContext.SaveChanges();

            var dbEntry = dbContext.ProductTypes.Where(entry => entry.ID == productType.ID).FirstOrDefault();

            return Results.CreatedAtRoute(GetNameEndpointName, new { id = productType.ID }, dbEntry.ToProductTypeDTO());
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
