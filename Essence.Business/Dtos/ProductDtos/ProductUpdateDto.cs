using Essence.Business.Abstractions.Dtos;
using Essence.Business.Dtos.ProductSizeDtos;
using Microsoft.AspNetCore.Http;

namespace Essence.Business.Dtos.ProductDtos;

public class ProductUpdateDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int Count { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public List<IFormFile>? NewProductImages { get; set; }
    public List<ProductSizeUpdateDto>? UpdatedProductSizes { get; set; }
    public List<int>? DeletedImageIds { get; set; } // Silinməsi üçün mövcud şəkil ID-ləri
}
