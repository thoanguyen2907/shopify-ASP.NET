using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopify.src.Abstraction;
using Shopify.src.Database;
using Shopify.src.DTO;
using Shopify.src.Entity;
using Shopify.src.Shared;

namespace Shopify.src.Repository
{
    public class ProductRepo : IProductRepo
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
        public async Task<IEnumerable<Product>> GetAllByCategoryIdAsync(Guid id, GetAllOptions getAllOptions)
        {
            var productList = await _products.Where(p => p.CategoryId == id).Include(p => p.Category).AsNoTracking().Skip(getAllOptions.Offset).Take(getAllOptions.Limit).ToArrayAsync();

            return productList;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(GetAllOptions getAllOptions)
        {
            if (getAllOptions.Search is null)
            {
                return await _products.Include(p => p.Category).Skip(getAllOptions.Offset).Take(getAllOptions.Limit).ToArrayAsync();
            }
            else
            {
                return await _products
                        .Where(p => p.Name.Contains(getAllOptions.Search))
                        .Include(p => p.Category)
                        .Skip(getAllOptions.Offset)
                        .Take(getAllOptions.Limit).ToArrayAsync();
            }
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