using Essence.Business.Abstractions.Dtos;

namespace Essence.Business.Dtos.ProductSizeDtos;

public class ProductSizeCreateDto:IDto
{
    public string Size { get; set; } = null!;
    public decimal Price { get; set; }
    public int Count { get; set; }
}
