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
            var foundItem = await _productRepo.GetByIdAsync(id) ?? throw CustomException.NotFound();
            var properties = updateDto!.GetType().GetProperties();
            foreach (var p in properties)
            {
                if(p.GetValue(foundItem) is not null && p.GetValue(updateDto) is null)
                {
                    p.SetValue(updateDto, p.GetValue(foundItem));
                }
            }
            //   var mappedItem = _mapper.Map<ProductUpdateDto, Product>(updateDto);
            //   Console.WriteLine("foundProduct " + foundProduct);
            // Console.WriteLine("mappedProduct " + mappedProduct);
            // Console.WriteLine("mappedItem " + mappedItem);
            return await _productRepo.UpdateOneAsync(_mapper.Map<ProductUpdateDto, Product>(updateDto));
        }
    }
}