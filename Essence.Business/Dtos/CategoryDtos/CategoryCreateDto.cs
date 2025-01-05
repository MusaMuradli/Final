using Essence.Business.Abstractions.Dtos;
using Microsoft.AspNetCore.Http;

namespace Essence.Business.Dtos.CategoryDtos;

public class CategoryCreateDto : IDto
{
    public IFormFile? Image { get; set; }
    public string Name { get; set; } = null!;
    public string ImagePath { get; set; } = null!;

}
