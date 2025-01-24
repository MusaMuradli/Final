using AutoMapper;
using Essence.Business.Dtos.CategoryDtos;
using Essence.Business.Dtos.ProductDtos;
using Essence.Core.Entities;

public class CategoryAutoMapperProfile : Profile
{
    public CategoryAutoMapperProfile()
    {
        CreateMap<Category, CategoryCreateDto>().ReverseMap();

        CreateMap<Category, CategoryGetDto>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products.Select(product => new ProductGetDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.ProductSizes.Any() ? product.ProductSizes.First().Price : 0, 
                Size = product.ProductSizes.Any() ? product.ProductSizes.First().Size : "N/A", 
                BrandName = product.Brand != null ? product.Brand.Name : "No Brand",
                MainImagePath = product.ProductImages != null && product.ProductImages.Any(img => img.IsMain)
    ? product.ProductImages.First(img => img.IsMain).Path
    : ""
            }).ToList()));
    }
}
