using Essence.Business.Abstractions.Dtos;
using Essence.Business.Dtos.ProductDtos;

namespace Essence.Business.Dtos.BrandDtos;

public class BrandCreateDto : IDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
    public List<ProductGetDto> Prodcuts { get; set; } = [];

}
