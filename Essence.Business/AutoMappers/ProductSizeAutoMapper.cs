using AutoMapper;
using Essence.Business.Dtos.ProductSizeDtos;
using Essence.Core.Entities;

namespace Essence.Business.AutoMappers;

internal class ProductSizeAutoMapper : Profile
{
    public ProductSizeAutoMapper()
    {
        CreateMap<ProductSize, ProductSizeCreateDto>().ReverseMap();
        CreateMap<ProductSize, ProductSizeUpdateDto>().ReverseMap();
        CreateMap<ProductSize, ProductSizeDto>().ReverseMap();
        CreateMap<ProductSize, ProductSizeRelationDto>().ReverseMap();
    }
}
