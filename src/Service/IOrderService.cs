using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.src.DTO;
using Shopify.src.Shared;

namespace Shopify.src.Service
{
  public interface IOrderService
  {
    Task<OrderReadDto> CreateOneAsync(Guid UserId, OrderCreateDto createDto);
    Task<bool> DeleteOneAsync(Guid id);
    Task<IEnumerable<OrderReadDto>> GetAllAsync(GetAllOptions getAllOptions);
    Task<OrderReadDto> GetByIdAsync(Guid id);
    //  Task<bool> UpdateOneAsync(Guid id, CategoryUpdateDto updateDto);
  }
}