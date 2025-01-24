using Essence.Business.Dtos.CategoryDtos;
using Essence.Business.Services.Abstractions.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Essence.Business.Services.Abstractions
{
    public interface ICategoryService : IModifyService<CategoryCreateDto, CategoryUpdateDto>
    {
        /// <summary>
        /// Bütün kateqoriyaları qaytarır.
        /// </summary>
        Task<List<CategoryGetDto>> GetAllCategories();

        /// <summary>
        /// Kateqoriyanın mövcudluğunu yoxlayır.
        /// </summary>
        Task<bool> IsExistAsync(int id);

        /// <summary>
        /// Yeni kateqoriya yaratmaq üçün boş DTO qaytarır.
        /// </summary>
        Task<CategoryCreateDto> GetCreateDtoAsync();

        /// <summary>
        /// Mövcud kateqoriya yaratma məlumatlarını qaytarır.
        /// </summary>
        Task<CategoryCreateDto> GetCreateDtoAsync(CategoryCreateDto dto);

        /// <summary>
        /// Kateqoriyanın yenilənməsi üçün məlumatları qaytarır.
        /// </summary>
        Task<CategoryUpdateDto> GetUpdatedDtoAsync(int id);

        /// <summary>
        /// Kateqoriyanı yeniləyir.
        /// </summary>
        Task<bool> UpdateAsync(CategoryUpdateDto dto, ModelStateDictionary ModelState);
    }
}
