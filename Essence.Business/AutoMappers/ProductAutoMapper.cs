using AutoMapper;
using Essence.Business.Dtos.ProductDtos;
using Essence.Core.Entities;

namespace Essence.Business.AutoMappers;

internal class ProductAutoMapper:Profile
{
    public ProductAutoMapper()
    {
        CreateMap<Product, ProductGetDto>().ReverseMap();
        CreateMap<ProductImage, ProductImageDto>().ReverseMap();
    }
}
