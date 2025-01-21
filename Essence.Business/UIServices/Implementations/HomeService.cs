using Essence.Business.Dtos.UIDtos;
using Essence.Business.Services.Abstractions;
using Essence.Business.UIServices.Abstractions;

namespace Essence.Business.UIServices.Implementations;

internal class HomeService : IHomeService
{
    private readonly IBrandService _brandService;
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;

    public HomeService(IBrandService brandService, ICategoryService categoryService, IProductService productService)
    {
        _brandService = brandService;
        _categoryService = categoryService;
        _productService = productService;
    }

    public async Task<HomeDto> GetHomeDtoAsync()
    {
        var products = await _productService.GetProductsAsync();
        var brands = await _brandService.GetBrandsAsync();
        var categories = await _categoryService.GetAllCategories();

        HomeDto dto = new HomeDto()
        {
            Brands = brands,
            Categories = categories,
            Products = products
        };
        return dto;
    }
}
