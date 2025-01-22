using Essence.Business.Abstractions.Dtos;
using Essence.Business.Dtos.ProductSizeDtos;

namespace Essence.Business.Dtos.BasketItemDtos;

public class BasketItemGetDto : IDto
{
    public int ProductSizeId { get; set; }
    public ProductSizeRelationDto ProductSize { get; set; } = null!;
    public int Count { get; set; }
}
