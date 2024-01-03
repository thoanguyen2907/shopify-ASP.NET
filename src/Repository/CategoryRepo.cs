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
    public class CategoryRepo : IBaseRepo<Category>

    {
        protected readonly DbSet<Category> _category;
        protected readonly DatabaseContext _databaseContext;
        public CategoryRepo(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _category = _databaseContext.Set<Category>();
        }
        public async Task<Category> CreateOneAsync(Category createObject)
        {
            await _category.AddAsync(createObject);
            await _databaseContext.SaveChangesAsync();
            return createObject;
        }

        public async Task<bool> DeleteOneAsync(Category deleteObject)
        {
            _category.Remove(deleteObject);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(GetAllOptions getAllOptions)
        {
            return await _category.Skip(getAllOptions.Offset).Take(getAllOptions.Limit).ToArrayAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _category.FindAsync(id);
        }

        public async Task<bool> UpdateOneAsync(Category updateObject)
        {
            _category.Update(updateObject);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}