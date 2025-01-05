using Essence.Business.Abstractions.Dtos;
using Essence.Business.Dtos.ProductSizeDtos;
using Microsoft.AspNetCore.Http;

namespace Essence.Business.Dtos.ProductDtos;

public class ProductCreateDto:IDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int Count { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public IFormFile MainImage { get; set; } = null!;
    public List<IFormFile> ProductImages { get; set; } = [];
    public List<ProductSizeCreateDto> ProductSizes { get; set; } = [];

}
