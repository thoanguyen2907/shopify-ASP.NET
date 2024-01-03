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
    public class CategoryService : ICategoryService
    {
        protected readonly IBaseRepo<Category> _categoryRepo;
        protected readonly IMapper _mapper;
        public CategoryService(IBaseRepo<Category> categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
        public async Task<CategoryReadDto> CreateOneAsync(CategoryCreateDto createDto)
        {
            var category = _mapper.Map<CategoryCreateDto, Category>(createDto);
            var categoryCreated = await _categoryRepo.CreateOneAsync(category);
            return _mapper.Map<Category, CategoryReadDto>(categoryCreated);
        }

        public async Task<bool> DeleteOneAsync(Guid id)
        {
            var foundCategory = await _categoryRepo.GetByIdAsync(id);
            if (foundCategory is not null)
            {
                return await _categoryRepo.DeleteOneAsync(foundCategory);
            }
            return false;
        }

        public async Task<IEnumerable<CategoryReadDto>> GetAllAsync(GetAllOptions getAllOptions)
        {
            var categoryList = await _categoryRepo.GetAllAsync(getAllOptions);
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryReadDto>>(categoryList);
        }

        public async Task<CategoryReadDto> GetByIdAsync(Guid id)
        {
            var foundCategory = await _categoryRepo.GetByIdAsync(id);
            if (foundCategory == null)
            {
                throw CustomException.NotFound("Not find category with ${id}");
            }
            return _mapper.Map<Category, CategoryReadDto>(foundCategory);
        }

        public async Task<bool> UpdateOneAsync(Guid id, CategoryUpdateDto updateDto)
        {
            var foundCategory = await _categoryRepo.GetByIdAsync(id) ?? throw CustomException.NotFound($"Category with {id} is not found"); ;
            if (foundCategory == null)
            {
                return false;
            }

            _mapper.Map(updateDto, foundCategory);
            return await _categoryRepo.UpdateOneAsync(foundCategory);
        }
    }
}