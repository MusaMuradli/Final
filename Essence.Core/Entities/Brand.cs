using Essence.Core.Entities.Common;

namespace Essence.Core.Entities;

public class Brand:BaseEntity
{
    public string Name { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
    public List<Product> Products { get; set; } = [];

}
