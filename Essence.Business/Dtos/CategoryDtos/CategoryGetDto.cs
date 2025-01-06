using Essence.Business.Abstractions.Dtos;
using Essence.Business.Dtos.ProductDtos;

namespace Essence.Business.Dtos.CategoryDtos;

public class CategoryGetDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? ImagePath { get; set; }
    public List<ProductGetDto> Products { get; set; } = [];

}
