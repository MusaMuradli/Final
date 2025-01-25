using Essence.Core.Entities.Common;
using Essence.Core.Enum;

namespace Essence.Core.Entities;

public class Product:BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int Count { get; set; }
    public Brand Brand { get; set; } = null!;
    public int BrandId { get; set; }
    public int? CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public List<ProductImage> ProductImages { get; set; } = [];
    public List<ProductSize> ProductSizes { get; set; } = [];



}
