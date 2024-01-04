using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.src.DTO;
using Shopify.src.Shared;

namespace Shopify.src.Service
{
    public interface IProductService
    {
        Task<ProductReadDto> CreateOneAsync(ProductCreateDto createDto);
        Task<bool> DeleteOneAsync(Guid id);
        Task<IEnumerable<ProductReadDto>> GetAllAsync(GetAllOptions getAllOptions);
        Task<ProductReadDto> GetByIdAsync(Guid id);
        Task<bool> UpdateOneAsync(Guid id, ProductUpdateDto updateDto);
    }
}