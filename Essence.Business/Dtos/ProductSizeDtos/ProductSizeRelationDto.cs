using Essence.Business.Abstractions.Dtos;
using Essence.Business.Dtos.ProductDtos;

namespace Essence.Business.Dtos.ProductSizeDtos;

public class ProductSizeRelationDto : IDto
{
    public string Size { get; set; } = null!;
    public decimal Price { get; set; }
    public int Count { get; set; }
    public int ProductId { get; set; }
    public ProductGetDto Product { get; set; } = null!;
}
