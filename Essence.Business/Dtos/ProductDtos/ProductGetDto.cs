using Essence.Core.Entities;

namespace Essence.Business.Dtos.ProductDtos;

public class ProductGetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
    public int Count { get; set; }
    public List<ProductImage> ProductImages { get; set; } = [];
    public List<ProductSize> ProductSizes { get; set; } = [];
}
