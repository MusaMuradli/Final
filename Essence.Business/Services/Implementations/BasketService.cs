using AutoMapper;
using Essence.Business.Dtos.BasketItemDtos;
using Essence.Business.Exceptions;
using Essence.Business.Services.Abstractions;
using Essence.Core.Entities;
using Essence.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Essence.Business.Services.Implementations;

internal class BasketService : IBasketService
{
    private readonly IBasketItemRepository _repository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IProductSizeService _productSizeService;
    private const string BASKET_KEY = "EssenceBasket";

    public BasketService(IBasketItemRepository repository, IMapper mapper, IHttpContextAccessor contextAccessor, IProductSizeService productSizeService)
    {
        _repository = repository;
        _mapper = mapper;
        _contextAccessor = contextAccessor;
        _productSizeService = productSizeService;
    }

    public async Task<bool> AddToBasketAsync(int id, int count = 1)
    {
        var isExistProductSize = await _productSizeService.IsExistAsync(id);

        if (isExistProductSize is false)
            throw new NotFoundException((nameof(NotFoundException)));


        

        if (_checkAuthorized())
        {
            string userId = _getUserId();

            var existBasketItem = await _repository.GetAsync(x => x.ProductSizeId == id && x.AppUserId == userId);

            if (existBasketItem is { })
            {
                existBasketItem.Count += count;

                _repository.Update(existBasketItem);
                await _repository.SaveChangesAsync();

                return true;
            }

            BasketItem basketItem = new() { AppUserId = userId, ProductSizeId = id, Count = count };

            await _repository.CreateAsync(basketItem);
            await _repository.SaveChangesAsync();

            return true;
        }
        else
        {
            var basketItems = _readBasketFromCookie();

            var existItem = basketItems.FirstOrDefault(x => x.ProductSizeId == id);

            if (existItem is { })
                existItem.Count += count;
            else
            {
                BasketItem newBasketItem = new() { ProductSizeId = id, Count = count };

                basketItems.Add(newBasketItem);
            }

            _writeBasketInCookie(basketItems);

            return true;
        }
    }

    public async Task ClearBasketAsync()
    {
        if (!_checkAuthorized())
        {
            _writeBasketInCookie(new());
            return;
        }

        string userId = _getUserId();

        var basketItems = await _repository.GetFilter(x => x.AppUserId == userId).ToListAsync();

        foreach (var basketItem in basketItems)
        {
            _repository.Delete(basketItem);
        }

        await _repository.SaveChangesAsync();
    }

    public async Task<bool> DecreaseToBasketAsync(int id)
    {
        var isExistProductSize = await _productSizeService.IsExistAsync(id);

        if (isExistProductSize is false)
            throw new NotFoundException((nameof(NotFoundException)));

        if (_checkAuthorized())
        {
            string userId = _getUserId();

            var existBasketItem = await _repository.GetAsync(x => x.ProductSizeId == id && x.AppUserId == userId);

            if (existBasketItem is null)
                throw new NotFoundException((nameof(NotFoundException)));

            if (existBasketItem.Count <= 1)
                return true;

            existBasketItem.Count--;

            _repository.Update(existBasketItem);
            await _repository.SaveChangesAsync();

            return true;

        }
        else
        {
            var basketItems = _readBasketFromCookie();

            var existItem = basketItems.FirstOrDefault(x => x.ProductSizeId == id);

            if (existItem is null)
                throw new NotFoundException((nameof(NotFoundException)));

            if (existItem.Count <= 1)
                return true;

            existItem.Count--;

            _writeBasketInCookie(basketItems);

            return true;
        }
    }

    public async Task<BasketGetDto> GetBasketAsync()
    {
        if (_checkAuthorized())
        {
            var userId = _getUserId();

            var basketItems = await _repository.GetFilter(
                x => x.AppUserId == userId,
                x => x.Include(x => x.ProductSize)
                      .ThenInclude(x => x.Product)
                      .Include(x => x.ProductSize.Product.Category)
                      .Include(x => x.ProductSize.Product.Brand)
                      .Include(x => x.ProductSize.Product.ProductImages)
            ).ToListAsync();

            var dtos = _mapper.Map<List<BasketItemGetDto>>(basketItems);

           
            var validDtos = new List<BasketItemGetDto>();

            foreach (var dto in dtos)
            {
                var productSize = await _productSizeService.GetAsync(dto.ProductSizeId);

                if (productSize != null)
                {
                    dto.ProductSize = productSize;
                    validDtos.Add(dto); 
                }
            }
            dtos = validDtos;

            decimal totalPrice = dtos.Sum(x => (x.Count * x.ProductSize.Price));
            var basketDto = new BasketGetDto()
            {
                Items = dtos,
                Count = dtos.Count,
                Subtotal = totalPrice,
                Total = totalPrice,
                Discount = 0,
            };

            return basketDto;
        }
        else
        {
            var basketItems = _readBasketFromCookie();
            var dtos = _mapper.Map<List<BasketItemGetDto>>(basketItems);

            var validDtos = new List<BasketItemGetDto>();

            foreach (var dto in dtos)
            {
                var productSize = await _productSizeService.GetAsync(dto.ProductSizeId);

                if (productSize != null)
                {
                    dto.ProductSize = productSize;
                    validDtos.Add(dto);
                }
            }

            dtos = validDtos;

            decimal totalPrice = dtos.Sum(x => (x.Count * x.ProductSize.Price));
            var basketDto = new BasketGetDto()
            {
                Items = dtos,
                Count = dtos.Count,
                Subtotal = totalPrice,
                Total = totalPrice,
                Discount = 0,
            };

            return basketDto;
        }
    }


    public async Task RemoveToBasketAsync(int id)
    {
        var isExistProductSize = await _productSizeService.IsExistAsync(id);

        if (isExistProductSize is false)
            throw new NotFoundException((nameof(NotFoundException)));

        if (_checkAuthorized())
        {
            string userId = _getUserId();

            var existBasketItem = await _repository.GetAsync(x => x.ProductSizeId == id && x.AppUserId == userId);

            if (existBasketItem is null)
                throw new NotFoundException((nameof(NotFoundException)));

            _repository.Delete(existBasketItem);
            await _repository.SaveChangesAsync();
        }
        else
        {
            List<BasketItem> basketItems = _readBasketFromCookie();

            var existItem = basketItems.FirstOrDefault(x => x.ProductSizeId == id);

            if (existItem is null)
                throw new NotFoundException((nameof(NotFoundException)));

            basketItems.Remove(existItem);

            _writeBasketInCookie(basketItems);
        }
    }

    private List<BasketItem> _readBasketFromCookie()
    {
        string json = _contextAccessor.HttpContext?.Request.Cookies[BASKET_KEY] ?? "";

        var basketItems = JsonConvert.DeserializeObject<List<BasketItem>>(json) ?? new();
        return basketItems;
    }
    private void _writeBasketInCookie(List<BasketItem> basketItems)
    {
        string newJson = JsonConvert.SerializeObject(basketItems);

        _contextAccessor.HttpContext?.Response.Cookies.Append(BASKET_KEY, newJson);
    }

    private string _getUserId()
    {
        return _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
    }

    private bool _checkAuthorized()
    {
        return _contextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
    }
}
