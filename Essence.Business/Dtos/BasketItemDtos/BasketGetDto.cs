using Essence.Business.Abstractions.Dtos;

namespace Essence.Business.Dtos.BasketItemDtos;

public class BasketGetDto : IDto
{
    public int Count { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }
    public List<BasketItemGetDto> Items { get; set; } = [];
}
