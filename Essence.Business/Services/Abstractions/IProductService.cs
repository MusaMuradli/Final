using Essence.Business.Dtos.BrandDtos;
using Essence.Business.Dtos.CategoryDtos;
using Essence.Business.Dtos.ProductDtos;
using Essence.Business.Services.Abstractions.Generic;

namespace Essence.Business.Services.Abstractions;

public interface IProductService:IModifyService<ProductCreateDto, ProductUpdateDto>, IGetService<ProductGetDto>
{
    Task<ProductUpdateDto> GetUpdatedDtoAsync(ProductUpdateDto dto);
    Task<List<BrandGetDto>> GetBrandsAsync();
    Task<List<CategoryGetDto>> GetCategoriesAsync();
    Task<List<ProductGetDto>> GetProductsAsync();
    Task<BrandAndCategoryDto> GetBrandAndCategoriesAsync();
    Task DeleteDtoAsync(int id);

}
