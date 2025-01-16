using AutoMapper;
using Essence.Business.Abstractions.Dtos;
using Essence.Business.Dtos.BrandDtos;
using Essence.Business.Dtos.CategoryDtos;
using Essence.Business.Dtos.ProductDtos;
using Essence.Business.Exceptions;
using Essence.Business.Extensions;
using Essence.Business.Services.Abstractions;
using Essence.Core.Entities;
using Essence.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Essence.Business.Services.Implementations
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;



        public ProductService(IProductRepository productRepository, IMapper mapper, ICloudinaryService cloudinaryService, ICategoryService categoryService, IBrandService brandService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _categoryService = categoryService;
            _brandService = brandService;
        }

        public async Task<bool> CreateAsync(ProductCreateDto dto, ModelStateDictionary ModelState)
        {
            if (!ModelState.IsValid)
                return false;

            var isExistCategory = await _categoryService.IsExistAsync(dto.CategoryId);

            if (!isExistCategory)
            {
                ModelState.AddModelError("CategoryId", "Belə Kateqoriya mövcud deyil zəhmət olmasa yenidən daxil edin");
                return false;
            }

            var isExistBrand = await _brandService.IsExistAsync(dto.BrandId);

            if (!isExistBrand)
            {
                ModelState.AddModelError("BrandId", "Belə Brend mövcud deyil zəhmət olmasa yenidən daxil edin");
                return false;
            }

            if (dto.ProductSizes.Count == 0)
            {
                ModelState.AddModelError("ProductSizes", "Minimum 1 ölçü daxil etməlisiniz");
                return false;
            }
            if (!dto.MainImage.ValidateType())
            {
                ModelState.AddModelError("MainImage", "Yalnız şəkil formatında dəyər daxil edə bilərsiniz");
                return false;
            }
            if (!dto.MainImage.ValidateSize(2))
            {
                ModelState.AddModelError("MainImage", "Şəkilin ölçüsü 2 mb dan artıq ola bilməz");
                return false;
            }
            foreach (var formFile in dto.ProductImages)
            {
                if (!formFile.ValidateType())
                {
                    ModelState.AddModelError("Images", "Yalnız şəkil formatında dəyər daxil edə bilərsiniz");
                    return false;
                }

                if (!formFile.ValidateSize(2))
                {
                    ModelState.AddModelError("Images", "Şəkilin ölçüsü 2 mb dan artıq ola bilməz");
                    return false;
                }
            }

            var product = _mapper.Map<Product>(dto);

            product.ProductImages = new List<ProductImage>();

            string mainImagePath = await _cloudinaryService.FileCreateAsync(dto.MainImage);
            ProductImage mainImage = new() { Path = mainImagePath, IsMain = true };
            product.ProductImages.Add(mainImage);

            foreach (var file in dto.ProductImages)
            {
                string imagePath = await _cloudinaryService.FileCreateAsync(file);
                ProductImage image = new() { Path = imagePath };
                product.ProductImages.Add(image);
            }
            await _productRepository.CreateAsync(product);
            await _productRepository.SaveChangesAsync();
            return true;
        }









        public async Task DeleteAsync(int id)
        {
            var product = await _productRepository.GetAsync(id);
            if (product == null)
                throw new NotFoundException();
            _productRepository.Delete(product);
            await _productRepository.SaveChangesAsync();

        }

        public Task DeleteDtoAsync(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<ProductGetDto> GetAsync(int id)
        {
            var product = await _productRepository.GetAsync(id, query =>
      query.Include(p => p.Brand)
           .Include(p => p.Category)
           .Include(p => p.ProductImages));

            if (product == null)
                throw new NotFoundException();

            return _mapper.Map<ProductGetDto>(product);
        }

        public Task<ProductCreateDto> GetCreatedDtoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductCreateDto> GetCreatedDtoAsync(ProductCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ProductUpdateDto> GetUpdatedDtoAsync(ProductUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ProductUpdateDto> GetUpdatedDtoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ProductUpdateDto dto, ModelStateDictionary ModelState)
        {
            throw new NotImplementedException();
        }

        public List<ProductGetDto> GetAll()
        {
            var products = _productRepository.GetAll(x => x.Include(x => x.ProductImages).Include(x => x.Brand).Include(x => x.Category));
            var dtos = _mapper.Map<List<ProductGetDto>>(products);
            return dtos;
        }

        public async Task<List<BrandGetDto>> GetBrandsAsync()
        {
            return await _brandService.GetBrandsAsync();
        }

        public async Task<List<CategoryGetDto>> GetCategoriesAsync()
        {
            return await _categoryService.GetAllCategories();
        }

        public async Task<BrandAndCategoryDto> GetBrandAndCategoriesAsync()
        {
            var brands = await _brandService.GetBrandsAsync();
            var categories = await _categoryService.GetAllCategories();

            var dto = new BrandAndCategoryDto
            {
                Brands = brands,
                Categories = categories
            };
            return dto;

        }

        public async Task<List<ProductGetDto>> GetProductsAsync()
        {
            var products = _productRepository.GetAll().Include(x => x.ProductImages)
                .Include(x => x.ProductSizes)
                .Include(x => x.Brand)
                .Include(x => x.Category);
            var dto = _mapper.Map<List<ProductGetDto>>(products);
            return dto;

        }
    }
}
