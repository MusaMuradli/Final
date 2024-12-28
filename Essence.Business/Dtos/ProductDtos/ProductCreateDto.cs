using Essence.Business.Abstractions.Dtos;

namespace Essence.Business.Dtos.ProductDtos;

public class ProductCreateDto:IDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public string Title { get; set; } = null!;


}
