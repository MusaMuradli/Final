using AutoMapper;
using Essence.Business.Dtos.ProductSizeDtos;
using Essence.Business.Services.Abstractions;
using Essence.DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Essence.Business.Services.Implementations;

internal class ProductSizeService : IProductSizeService
{
    private readonly IProductSizeRepository _repository;
    private readonly IMapper _mapper;

    public ProductSizeService(IProductSizeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductSizeRelationDto?> GetAsync(int id)
    {
        var productSize = await _repository.GetAsync(id, x => x.Include(x => x.Product)
                                               .ThenInclude(x => x.ProductImages.Where(x => x.IsMain == x.IsMain))
                                               .Include(x => x.Product.Category)
                                               .Include(x => x.Product.ProductImages));

        if (productSize is null)
            return null;

        var dto = _mapper.Map<ProductSizeRelationDto>(productSize);

        return dto;
    }

    public async Task<bool> IsExistAsync(int id)
    {
        return await _repository.IsExistAsync(x => x.Id == id);
    }
}

