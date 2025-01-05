using Essence.Business.Dtos.BrandDtos;
using Essence.Business.Dtos.ProductDtos;
using Essence.Business.Services.Abstractions.Generic;

namespace Essence.Business.Services.Abstractions;

public interface IProductService:IModifyService<ProductCreateDto, ProductUpdateDto>, IGetService<ProductGetDto>
{
    Task<ProductCreateDto> GetCreatedDtoAsync();
    Task<ProductCreateDto> GetCreatedDtoAsync(ProductCreateDto dto);
    Task<ProductUpdateDto> GetUpdatedDtoAsync(ProductUpdateDto dto);
    Task<List<BrandGetDto>> GetBrandsAsync();
    Task DeleteDtoAsync(int id);

}
