using Essence.Business.Dtos.CategoryDtos;
using Essence.Business.Services.Abstractions.Generic;

namespace Essence.Business.Services.Abstractions;

public interface ICategoryService : IModifyService<CategoryCreateDto, CategoryUpdateDto>
{
    Task<List<CategoryGetDto>> GetAllCategories(); 
    Task<bool> IsExistAsync(int id);
    Task<CategoryCreateDto> GetCreateDtoAsync();
    Task<CategoryUpdateDto> GetUpdatedDtoAsync(CategoryUpdateDto dto);
    
    
}
