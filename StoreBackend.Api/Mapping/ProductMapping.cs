using System;
using StoreBackend.Api.DTOs;
using StoreBackend.Api.Entities;

namespace StoreBackend.Api.Mapping;

public static class ProductMapping
{
    public static ProductSummaryDTO ToProductDTO(this Product product)
    {
        ProductSummaryDTO productDTO = new(

            product.ID,
            product.Name,
            product.Price,
            product.CurrentStock,
            product.productTypeId,
            product.ProductType!.Name
        );

        return productDTO;
    }

    public static Product ToProductEntity(this CreateProductDTO productDto)
    {
        return new Product()
        {
            Name = productDto.name,
            Price = productDto.price,
            CurrentStock = productDto.initialStock,
            productTypeId = productDto.productType
        };
    }
}
