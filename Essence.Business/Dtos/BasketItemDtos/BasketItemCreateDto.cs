using Essence.Business.Abstractions.Dtos;

namespace Essence.Business.Dtos.BasketItemDtos;

public class BasketItemCreateDto : IDto
{
    public int ProductSizeId { get; set; }
}
