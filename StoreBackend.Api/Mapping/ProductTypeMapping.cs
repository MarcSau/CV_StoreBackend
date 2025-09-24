using System;
using StoreBackend.Api.DTOs;
using StoreBackend.Api.Entities;

namespace StoreBackend.Api.Mapping;

public static class ProductTypeMapping
{
    public static ProductTypeSummaryDTO ToProductTypeDTO(this ProductType product)
    {
        ProductTypeSummaryDTO productDTO = new(product.ID,product.Name);

        return productDTO;
    }

    public static ProductType ToProductTypeEntity(this CreateProductTypeDTO productTypeDto)
    {
        return new ProductType()
        {
            Name = productTypeDto.name,
        };
    }
}
