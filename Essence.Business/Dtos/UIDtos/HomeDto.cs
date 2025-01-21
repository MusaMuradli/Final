using Essence.Business.Abstractions.Dtos;
using Essence.Business.Dtos.BrandDtos;
using Essence.Business.Dtos.CategoryDtos;
using Essence.Business.Dtos.ProductDtos;

namespace Essence.Business.Dtos.UIDtos;

public class HomeDto: IDto
{
    public List<ProductGetDto> Products { get; set; } = [];
    public List<BrandGetDto> Brands { get; set; } = [];
    public List<CategoryGetDto> Categories { get; set; } = [];

}
