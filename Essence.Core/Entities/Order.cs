using Essence.Core.Entities.Common;

namespace Essence.Core.Entities;

public class Order:BaseAuditableEntity
{
    public AppUser? AppUser { get; set; } = null!;
    public string? AppUserId { get; set; } = null!;
    public decimal TotalPrice { get; set; }
    public int StatusId { get; set; }
    public Status Status { get; set; } = null!;
    public List<OrderItem> OrderItems { get; set; } = [];

}
