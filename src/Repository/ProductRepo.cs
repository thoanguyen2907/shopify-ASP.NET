using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopify.src.Abstraction;
using Shopify.src.Database;
using Shopify.src.Entity;
using Shopify.src.Shared;

namespace Shopify.src.Repository
{
    public class ProductRepo : IBaseRepo<Product>
    {
        protected readonly DbSet<Product> _products;
        protected readonly DatabaseContext _databaseContext;
        public ProductRepo(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _products = _databaseContext.Set<Product>();
        }

        public async Task<Product> CreateOneAsync(Product createObject)
        {
            await _products.AddAsync(createObject);
            await _databaseContext.SaveChangesAsync();
            return createObject;
        }

        public async Task<bool> DeleteOneAsync(Product deleteObject)
        {
            _products.Remove(deleteObject);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(GetAllOptions getAllOptions)
        {
            return await _products.Skip(getAllOptions.Offset).Take(getAllOptions.Limit).ToArrayAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _products.FindAsync(id);
        }

        public async Task<bool> UpdateOneAsync(Product updateObject)
        {
            _products.Update(updateObject);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}