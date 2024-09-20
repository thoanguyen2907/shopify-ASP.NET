using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.src.DTO;
using Shopify.src.Shared;

namespace Shopify.src.Service
{
    public interface IOrderDetailService
    {
    Task<IEnumerable<OrderDetailReadDto>> GetAllAsync(GetAllOptions getAllOptions);
    Task<OrderDetailReadDto> GetByIdAsync(Guid id);
    }
}