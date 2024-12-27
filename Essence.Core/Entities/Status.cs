using Essence.Core.Entities.Common;

namespace Essence.Core.Entities;

public class Status : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public List<Order> Orders { get; set; } = [];

}
