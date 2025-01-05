using Essence.Business.Abstractions.Dtos;
using Essence.Business.Dtos.ProductDtos;
using Microsoft.AspNetCore.Http;

namespace Essence.Business.Dtos.BrandDtos;

public class BrandUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }=null!;
    public IFormFile? Image { get; set; }
    public string? ImagePath { get; set; }
    public List<ProductGetDto> Prodcuts { get; set; } = [];

}
