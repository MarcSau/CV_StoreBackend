using System.ComponentModel.DataAnnotations;
namespace StoreBackend.Api.DTOs;

public record class CreateProductTypeDTO
(
    [Required][StringLength(35)] string name
);