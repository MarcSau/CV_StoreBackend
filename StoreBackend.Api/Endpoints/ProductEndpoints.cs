using System;
using StoreBackend.Api.DTOs;

namespace StoreBackend.Api.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("product").WithParameterValidation();

        group.MapPut("/", (CreateProductDTO newProduct) =>
        {

        });

        group.MapGet("/", (int id) =>
        {

        });
    }
}
