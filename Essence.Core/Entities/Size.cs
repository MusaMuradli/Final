using Essence.Core.Entities.Common;
using Essence.Core.Enum;

namespace Essence.Core.Entities;

public class Size:BaseEntity
{
    public List<ProductSize> ProductSizes { get; set; } = [];
    public int Count { get; set; }
    public SizeType Sizes { get; set; }
}
