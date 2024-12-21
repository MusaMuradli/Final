using Essence.Core.Entities.Common;

namespace Essence.Core.Entities;

public class ProductSize:BaseEntity
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int SizeId { get; set; }
    public Size Size { get; set; }=null!;
}
