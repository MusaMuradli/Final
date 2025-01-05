using AutoMapper;
using Essence.Business.Dtos.BrandDtos;
using Essence.Business.Services.Abstractions;
using Essence.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Essence.Business.Services.Implementations;

internal class BrandService : IBrandService
{
    private readonly IBrandRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;

    public BrandService(IBrandRepository repository, IMapper mapper, ICloudinaryService cloudinaryService)
    {
        _repository = repository;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
    }

    public Task<bool> CreateAsync(BrandCreateDto dto, ModelStateDictionary ModelState)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<BrandRelationDto>> GetAllForProductAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<BrandGetDto>> GetBrandsAsync()
    {
        var brands = await _repository.GetAll().ToListAsync();

        var brandDtos = brands.Select(brand => new BrandGetDto
        {
            Id = brand.Id,
            Name = brand.Name
        }).ToList();

        return brandDtos;
    }

    public Task<BrandUpdateDto> GetUpdatedDtoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExistAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(BrandUpdateDto dto, ModelStateDictionary ModelState)
    {
        throw new NotImplementedException();
    }
}
