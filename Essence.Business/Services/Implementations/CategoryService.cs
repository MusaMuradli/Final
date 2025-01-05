using AutoMapper;
using Essence.Business.Dtos.CategoryDtos;
using Essence.Business.Services.Abstractions;
using Essence.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Essence.Business.Services.Implementations;

internal class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, ICloudinaryService cloudinaryService)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
    }

    public Task<bool> CreateAsync(CategoryCreateDto dto, ModelStateDictionary ModelState)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CategoryGetDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryCreateDto> GetCreateDtoAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryUpdateDto> GetUpdatedDtoAsync(CategoryUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryUpdateDto> GetUpdatedDtoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExistAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(CategoryUpdateDto dto, ModelStateDictionary ModelState)
    {
        throw new NotImplementedException();
    }
}
