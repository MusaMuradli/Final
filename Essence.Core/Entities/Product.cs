using Essence.Core.Entities.Common;
using Essence.Core.Enum;

namespace Essence.Core.Entities;

public class Product:BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
    public int Count { get; set; }
    public List<ProductImage> ProductImages { get; set; } = [];
    public List<ProductSize> ProductSizes { get; set; } = [];



}
