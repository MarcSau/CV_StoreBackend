using System;
using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.DTOs;

public record class ProductTypeSummaryDTO
(
    [Required] int id,
    [Required] string name
);
