using Essence.Core.Entities.Common;

namespace Essence.Core.Entities;

public class Category:BaseAuditableEntity
{
    public string? ImagePath { get; set; }
    public string Name { get; set; } = null!;

    public List<Product> Products { get; set; } = new();
}
