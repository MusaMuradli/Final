using Essence.Business.Dtos.CategoryDtos;
using Essence.Business.Services.Abstractions.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Essence.Business.Services.Abstractions
{
    public interface ICategoryService : IModifyService<CategoryCreateDto, CategoryUpdateDto>
    {
        Task<List<CategoryGetDto>> GetAllCategories();

        Task<bool> IsExistAsync(int id);

        Task<CategoryCreateDto> GetCreateDtoAsync();

        Task<CategoryCreateDto> GetCreateDtoAsync(CategoryCreateDto dto);

        Task<CategoryUpdateDto> GetUpdatedDtoAsync(int id);

        Task<bool> UpdateAsync(CategoryUpdateDto dto, ModelStateDictionary ModelState);
        Task<List<CategoryGetDto>> GetDeletedCategories();
    }
}
