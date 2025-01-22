using AutoMapper;
using Essence.Business.Dtos.BasketItemDtos;
using Essence.Core.Entities;

namespace Essence.Business.AutoMappers;

internal class BasketItemAutoMapper : Profile
{
    public BasketItemAutoMapper()
    {
        CreateMap<BasketItem, BasketItemCreateDto>().ReverseMap();
        CreateMap<BasketItem, BasketItemGetDto>().ReverseMap();
    }
}
