using AutoMapper;
using Essence.Business.Dtos.ProductDtos;
using Essence.Business.Dtos.ProductSizeDtos;
using Essence.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Essence.Business.AutoMappers;

internal class ProductAutoMapper : Profile
{
    public ProductAutoMapper()
    {
        CreateMap<Product, ProductGetDto>().ReverseMap();
        CreateMap<ProductImage, ProductImageDto>().ReverseMap();
        CreateMap<Product, ProductCreateDto>().ReverseMap();
        CreateMap<ProductCreateDto, Product>()
           .ForMember(dest => dest.ProductImages, opt => opt.Ignore()) 
           .ForMember(dest => dest.ProductSizes, opt => opt.MapFrom(src => src.ProductSizes));

     
        CreateMap<IFormFile, ProductImage>()
            .ForMember(dest => dest.Path, opt => opt.Ignore()) 
            .ForMember(dest => dest.IsMain, opt => opt.Ignore()) 
            .ForMember(dest => dest.IsHover, opt => opt.Ignore()); 
        CreateMap<ProductSizeCreateDto, ProductSize>();

        CreateMap<Product, ProductGetDto>()
    .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : "Məlumat yoxdur")) 
    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : "Məlumat yoxdur"))
             .ForMember(x => x.MainImagePath, x => x.MapFrom(src => src.ProductImages.FirstOrDefault(img => img.IsMain) != null ? src.ProductImages.FirstOrDefault(img => img.IsMain)!.Path : string.Empty))
             .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.ProductSizes.Any() ? src.ProductSizes.First().Price : 0))
             .ForMember(dest=>dest.CategoryName, opt=>opt.MapFrom(src=>src.Category.Name))
             .ForMember(dest=>dest.BrandName, opt=>opt.MapFrom(src=>src.Brand.Name))
             .ForMember(dest => dest.ImagePaths, opt => opt.MapFrom(src =>
        src.ProductImages != null
        ? src.ProductImages.Where(img => !img.IsMain).Select(img => img.Path).ToList()
        : new List<string>()));

        CreateMap<ProductSize, ProductSizeDto>();



    }
}
