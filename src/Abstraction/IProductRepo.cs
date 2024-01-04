using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.src.DTO;
using Shopify.src.Entity;
using Shopify.src.Shared;

namespace Shopify.src.Abstraction
{
    public interface IProductRepo : IBaseRepo<Product>
    {
        Task<IEnumerable<Product>> GetAllByCategoryIdAsync(Guid id, GetAllOptions getAllOptions);
    }
}