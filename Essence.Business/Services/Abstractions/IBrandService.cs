using Essence.Business.Dtos.BrandDtos;
using Essence.Business.Services.Abstractions.Generic;

namespace Essence.Business.Services.Abstractions;

public interface IBrandService : IModifyService<BrandCreateDto, BrandUpdateDto>
{
    Task<List<BrandRelationDto>> GetAllForProductAsync();
    Task<bool> IsExistAsync(int id);

    Task<List<BrandGetDto>> GetBrandsAsync();

}
