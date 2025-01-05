using Essence.Business.Abstractions.Dtos;
using Microsoft.AspNetCore.Http;

namespace Essence.Business.Dtos.CategoryDtos;

public class CategoryUpdateDto : IDto
{
    public int Id { get; set; }
    public IFormFile? Image { get; set; }
    public string? ImagePath { get; set; }
    public string Name { get; set; } = null!;

}
