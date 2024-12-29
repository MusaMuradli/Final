using Essence.Business.Abstractions.Dtos;

namespace Essence.Business.Dtos.ProductDtos;

public class ProductImageDto:IDto
{
    public int Id { get; set; }
    public string Path { get; set; } = null!;
    public bool IsHover { get; set; }
    public bool IsMain { get; set; }
}
