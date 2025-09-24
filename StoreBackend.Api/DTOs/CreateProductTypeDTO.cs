using System;
using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.DTOs;

public record class CreateProductTypeDTO
(
    [Required] string name
);
