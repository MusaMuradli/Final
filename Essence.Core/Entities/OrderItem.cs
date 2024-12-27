using Essence.Core.Entities.Common;

namespace Essence.Core.Entities;

public class OrderItem: BaseAuditableEntity
{
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public int ProductSizeId { get; set; }
    public ProductSize ProductSize { get; set; } = null!;
    public int Count { get; set; } 
    public decimal Price { get; set; } 
    public decimal TotalPrice { get; set; } // Məhsulun ümumi qiyməti (Quantity * UnitPrice)
}
