using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.src.DTO;
using Shopify.src.Shared;

namespace Shopify.src.Service
{
    public interface ICategoryService
    {
        Task<CategoryReadDto> CreateOneAsync(CategoryCreateDto createDto);
        Task<bool> DeleteOneAsync(Guid id);
        Task<IEnumerable<CategoryReadDto>> GetAllAsync(GetAllOptions getAllOptions);
        Task<CategoryReadDto> GetByIdAsync(Guid id);
        Task<bool> UpdateOneAsync(Guid id, CategoryUpdateDto updateDto);
    }
}