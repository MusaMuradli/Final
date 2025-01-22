using Essence.Business.Dtos.ProductSizeDtos;

namespace Essence.Business.Services.Abstractions;

public interface IProductSizeService
{
    Task<bool> IsExistAsync(int id);
    Task<ProductSizeRelationDto?> GetAsync(int id);
}
