using Essence.Business.Abstractions.Dtos;
using Essence.Business.Dtos.ProductSizeDtos;
using Essence.Core.Entities;

namespace Essence.Business.Dtos.ProductDtos;

public class ProductGetDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int Count { get; set; }
    public string BrandName { get; set; } = null!;// Brend adı
    public string CategoryName { get; set; } = null!; // Kateqoriya adı
    public Brand Brand { get; set; } = null!;
    public decimal Price { get; set; }

    public string MainImagePath { get; set; } = null!;
    public List<string> ImagePaths { get; set; } = [];
    public List<ProductImageDto> ProductImages { get; set; } = [];

    public Category Category { get; set; } = null!;
    public List<ProductSizeDto> ProductSizes { get; set; } = [];
}
