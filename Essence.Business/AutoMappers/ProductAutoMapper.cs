using AutoMapper;
using Essence.Business.Dtos.ProductDtos;
using Essence.Business.Dtos.ProductSizeDtos;
using Essence.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Essence.Business.AutoMappers;

internal class ProductAutoMapper:Profile
{
    public ProductAutoMapper()
    {
        CreateMap<Product, ProductGetDto>().ReverseMap();
        CreateMap<ProductImage, ProductImageDto>().ReverseMap();
        CreateMap<Product, ProductCreateDto>().ReverseMap();
        CreateMap<ProductCreateDto, Product>()
           .ForMember(dest => dest.ProductImages, opt => opt.Ignore()) // Manual olaraq təyin ediləcək
           .ForMember(dest => dest.ProductSizes, opt => opt.MapFrom(src => src.ProductSizes));

        // IFormFile -> ProductImage xəritəsi
        CreateMap<IFormFile, ProductImage>()
            .ForMember(dest => dest.Path, opt => opt.Ignore()) // Cloudinary ilə əl ilə yaradılacaq
            .ForMember(dest => dest.IsMain, opt => opt.Ignore()) // Əl ilə təyin ediləcək
            .ForMember(dest => dest.IsHover, opt => opt.Ignore()); // Əl ilə təyin ediləcək
        CreateMap<ProductSizeCreateDto, ProductSize>();
        CreateMap<Product, ProductGetDto>()
                      .ForMember(x => x.MainImagePath, x => x.MapFrom(src => src.ProductImages.FirstOrDefault(img => img.IsMain) != null ? src.ProductImages.FirstOrDefault(img => img.IsMain)!.Path : string.Empty))
                      .ForMember(x => x.ImagePaths, x => x.MapFrom(src => src.ProductImages.Where(x => !x.IsMain).Select(x => x.Path)));


    }
}
