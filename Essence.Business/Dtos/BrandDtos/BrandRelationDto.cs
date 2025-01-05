using Essence.Business.Abstractions.Dtos;
using Essence.Business.Dtos.ProductDtos;

namespace Essence.Business.Dtos.BrandDtos;

public class BrandRelationDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<ProductGetDto> Products { get; set; } = [];
}

