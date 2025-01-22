using Essence.Business.Dtos.BasketItemDtos;

namespace Essence.Business.Services.Abstractions;


public interface IBasketService
{
    Task<bool> AddToBasketAsync(int id, int count = 1);
    Task<bool> DecreaseToBasketAsync(int id);
    Task RemoveToBasketAsync(int id);
    Task<BasketGetDto> GetBasketAsync();
    Task ClearBasketAsync();
}

