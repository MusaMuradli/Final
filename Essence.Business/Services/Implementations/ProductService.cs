using AutoMapper;
using Essence.Business.Dtos.ProductDtos;
using Essence.Business.Services.Abstractions;
using Essence.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Essence.Business.Services.Implementations
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<bool> CreateAsync(ProductCreateDto dto, ModelStateDictionary ModelState)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDtoAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<ProductGetDto> GetAsync(int id)
        {
            throw new NotImplementedException();
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
            var products = _productRepository.GetAll(x => x.Include(x => x.ProductImages).Include(x=>x.Brand).Include(x=>x.Category));
            var dtos = _mapper.Map<List<ProductGetDto>>(products);
            return dtos;
        }
    }
}
