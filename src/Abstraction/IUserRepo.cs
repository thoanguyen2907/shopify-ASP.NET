using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.src.Entity;

namespace Shopify.src.Abstraction
{
    public interface IUserRepo : IBaseRepo<User>
    {
        Task<User?> FindByEmailAsync(string email);
    }
}