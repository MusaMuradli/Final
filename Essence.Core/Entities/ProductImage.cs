using Essence.Core.Entities.Common;

namespace Essence.Core.Entities;

public class ProductImage:BaseEntity
{
    public string Path { get; set; } = null!;
    public bool IsHover {  get; set; }=false;
    public bool IsMain { get; set; } = false;
    public Product Product { get; set; } = null!;
    public int ProductId { get; set; }
    public List<ProductSize> ProductSizes { get; set; } = [];
}
