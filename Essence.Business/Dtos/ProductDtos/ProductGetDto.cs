using Essence.Business.Abstractions.Dtos;
using Essence.Core.Entities;

namespace Essence.Business.Dtos.ProductDtos;

public class ProductGetDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Brand Brand { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
    public int Count { get; set; }
    public Category Category { get; set; } = null!;
    public List<ProductImageDto> ProductImages { get; set; } = [];
    public List<ProductSize> ProductSizes { get; set; } = [];
}
