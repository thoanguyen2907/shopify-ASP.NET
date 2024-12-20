using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopify.src.Abstraction;
using Shopify.src.Database;
using Shopify.src.DTO;
using Shopify.src.Entity;
using Shopify.src.Shared;

namespace Shopify.src.Repository
{
    public class UserRepo : IUserRepo
    {
        protected readonly DbSet<User> _users;
        protected readonly DatabaseContext _databaseContext;
        public UserRepo(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _users = _databaseContext.Set<User>();
        }
        public async Task<User> CreateOneAsync(User createObject)
        {
            await _users.AddAsync(createObject);
            await _databaseContext.SaveChangesAsync();
            return createObject;
        }

        public async Task<bool> DeleteOneAsync(User deleteObject)
        {
            _users.Remove(deleteObject);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            var user = await _users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync(GetAllOptions getAllOptions)
        {
            return await _users.Skip(getAllOptions.Offset).AsNoTracking().Take(getAllOptions.Limit).ToArrayAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _users.FindAsync(id);
        }

        public async Task<bool> UpdateOneAsync(User updateObject)
        {
            _users.Update(updateObject);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}