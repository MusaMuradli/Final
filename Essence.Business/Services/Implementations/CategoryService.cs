using AutoMapper;
using Essence.Business.Dtos.BrandDtos;
using Essence.Business.Dtos.CategoryDtos;
using Essence.Business.Services.Abstractions;
using Essence.Core.Entities;
using Essence.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Essence.Business.Services.Implementations;

internal class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, ICloudinaryService cloudinaryService)
    {
        _repository = categoryRepository;
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

    public async Task<List<CategoryGetDto>> GetAllCategories()
    {
        var categories = await _repository.GetAll().ToListAsync();
        var categoryDtos = categories.Select(category => new CategoryGetDto
        {
            Id = category.Id,
            Name = category.Name
        }).ToList();

        return categoryDtos;
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

    public async Task<bool> IsExistAsync(int id)
    {
       var category = await _repository.IsExistAsync(x=>x.Id == id);
        return category;
    }

    public Task<bool> UpdateAsync(CategoryUpdateDto dto, ModelStateDictionary ModelState)
    {
        throw new NotImplementedException();
    }
}
