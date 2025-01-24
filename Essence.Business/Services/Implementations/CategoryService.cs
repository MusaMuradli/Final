using AutoMapper;
using Essence.Business.Dtos.CategoryDtos;
using Essence.Business.Exceptions;
using Essence.Business.Extensions;
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

    public CategoryService(ICategoryRepository repository, IMapper mapper, ICloudinaryService cloudinaryService)
    {
        _repository = repository;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
    }

    public async Task<bool> CreateAsync(CategoryCreateDto dto, ModelStateDictionary ModelState)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            ModelState.AddModelError("Name", "Kateqoriya adı boş ola bilməz.");
            return false;
        }

        if (!char.IsUpper(dto.Name[0]))
        {
            ModelState.AddModelError("Name", "Kateqoriya adının ilk hərfi böyük olmalıdır.");
            return false;
        }

        if (await _repository.IsExistAsync(x => x.Name.ToLower() == dto.Name.ToLower()))
        {
            ModelState.AddModelError("Name", "Bu adda kateqoriya artıq mövcuddur.");
            return false;
        }

        if (dto.Image != null)
        {
            if (!dto.Image.ValidateSize(2))
            {
                ModelState.AddModelError("Image", "Şəklin həcmi 2 mb-dan çox olmamalıdır.");
                return false;
            }
            if (!dto.Image.ValidateType())
            {
                ModelState.AddModelError("Image", "Yalnız şəkil formatında fayl yükləyin.");
                return false;
            }
        }

        var category = _mapper.Map<Category>(dto);

        if (dto.Image != null)
        {
            string imagePath = await _cloudinaryService.FileCreateAsync(dto.Image);
            category.ImagePath = imagePath;
        }

        await _repository.CreateAsync(category);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _repository.GetAsync(id);

        if (category == null)
            throw new NotFoundException("Kateqoriya tapılmadı.");

        if (!string.IsNullOrEmpty(category.ImagePath))
            await _cloudinaryService.FileDeleteAsync(category.ImagePath);

        _repository.Delete(category);
        await _repository.SaveChangesAsync();
    }

    public async Task<List<CategoryGetDto>> GetAllCategories()
    {
        var categories = await _repository.GetAll(query => query
     .Include(c => c.Products)
     .ThenInclude(p => p.ProductSizes) 
     .Include(c => c.Products)
     .ThenInclude(p => p.Brand))
     .ToListAsync();

        var categoryDtos = _mapper.Map<List<CategoryGetDto>>(categories);
        return categoryDtos;
    }

    public async Task<CategoryCreateDto> GetCreateDtoAsync()
    {
        return await Task.FromResult(new CategoryCreateDto());
    }

    public async Task<CategoryCreateDto> GetCreateDtoAsync(CategoryCreateDto dto)
    {
        return await Task.FromResult(dto); 
    }

    public async Task<CategoryUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var category = await _repository.GetAsync(id);

        if (category == null)
            throw new NotFoundException("Kateqoriya tapılmadı.");

        var dto = _mapper.Map<CategoryUpdateDto>(category);
        return dto;
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _repository.IsExistAsync(x => x.Id == id);
    }

    public async Task<bool> UpdateAsync(CategoryUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            ModelState.AddModelError("Name", "Kateqoriya adı boş ola bilməz.");
            return false;
        }

        if (!char.IsUpper(dto.Name[0]))
        {
            ModelState.AddModelError("Name", "Kateqoriya adının ilk hərfi böyük olmalıdır.");
            return false;
        }

        var category = await _repository.GetAsync(dto.Id);

        if (category == null)
        {
            ModelState.AddModelError("Id", "Kateqoriya tapılmadı.");
            return false;
        }


        if (await _repository.IsExistAsync(x => x.Name.ToLower() == dto.Name.ToLower() && x.Id != dto.Id))
        {
            ModelState.AddModelError("Name", "Bu adda kateqoriya artıq mövcuddur.");
            return false;
        }

        category.Name = dto.Name;

        if (dto.Image != null)
        {
            if (!string.IsNullOrEmpty(category.ImagePath))
                await _cloudinaryService.FileDeleteAsync(category.ImagePath);

            string imagePath = await _cloudinaryService.FileCreateAsync(dto.Image);
            category.ImagePath = imagePath;
        }

        _repository.Update(category);
        await _repository.SaveChangesAsync();

        return true;
    }
}
