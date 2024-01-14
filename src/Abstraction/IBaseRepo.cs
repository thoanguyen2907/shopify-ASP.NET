using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.src.Entity;
using Shopify.src.Shared;

namespace Shopify.src.Abstraction
{
    public interface IBaseRepo<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(GetAllOptions getAllOptions);
        Task<T?> GetByIdAsync(Guid id);
        Task<bool> UpdateOneAsync(T updateObject);
        Task<bool> DeleteOneAsync(T deleteObject);
        Task<T> CreateOneAsync(T createObject);
    }
}