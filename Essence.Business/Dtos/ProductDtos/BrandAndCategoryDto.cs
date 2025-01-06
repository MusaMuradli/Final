using Essence.Business.Abstractions.Dtos;
using Essence.Business.Dtos.BrandDtos;
using Essence.Business.Dtos.CategoryDtos;

namespace Essence.Business.Dtos.ProductDtos;

public class BrandAndCategoryDto:IDto
{
    public List<BrandGetDto> Brands { get; set; } = [];
    public List<CategoryGetDto> Categories { get; set; } = [];
}
