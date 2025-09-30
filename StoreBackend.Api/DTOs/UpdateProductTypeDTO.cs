using System.ComponentModel.DataAnnotations;
namespace StoreBackend.Api.DTOs;

public record class UpdateProductTypeDTO
(
    [Required] string name
);