using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shopify.src.Abstraction;
using Shopify.src.DTO;
using Shopify.src.Entity;
using Shopify.src.Shared;

namespace Shopify.src.Service.Impl
{
    public class ProductService : IProductService
    {
        protected readonly IProductRepo _productRepo;
        protected readonly IMapper _mapper;
        public ProductService(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }
        public async Task<ProductReadDto> CreateOneAsync(ProductCreateDto createDto)
        {
            var product = _mapper.Map<ProductCreateDto, Product>(createDto);
            var productCreated = await _productRepo.CreateOneAsync(product);
            return _mapper.Map<Product, ProductReadDto>(productCreated);
        }

        public async Task<bool> DeleteOneAsync(Guid id)
        {
            var foundProduct = await _productRepo.GetByIdAsync(id);
            if (foundProduct is null)
            {
                return false;
            }
            return await _productRepo.DeleteOneAsync(foundProduct);
        }

        public async Task<IEnumerable<ProductReadDto>> GetAllAsync(GetAllOptions getAllOptions)
        {
            var productList = await _productRepo.GetAllAsync(getAllOptions);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductReadDto>>(productList);
        }

        public async Task<IEnumerable<ProductReadDto>> GetProductsByCategoryIdAsync(Guid id, GetAllOptions getAllOptions)
        {
            var productList = await _productRepo.GetAllByCategoryIdAsync(id, getAllOptions);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductReadDto>>(productList);
        }

        public async Task<ProductReadDto> GetByIdAsync(Guid id)
        {
            var foundProduct = await _productRepo.GetByIdAsync(id);
            if (foundProduct is null)
            {
                throw CustomException.NotFound("Product with ${id} is nout found !");
            }
            return _mapper.Map<Product, ProductReadDto>(foundProduct);
        }


        public async Task<bool> UpdateOneAsync(Guid id, ProductUpdateDto updateDto)
        {
            var foundProduct = await _productRepo.GetByIdAsync(id);

            if (foundProduct == null)
            {
                return false;
            }

            foreach (var property in updateDto.GetType().GetProperties())
            {
                if (property.GetValue(updateDto) is null)
                {
                    property.SetValue(updateDto, foundProduct.GetType().GetProperty(property.Name).GetValue(foundProduct));
                }
            }
            var mappedProduct = _mapper.Map(updateDto, foundProduct);
            return await _productRepo.UpdateOneAsync(mappedProduct);
        }
    }
}