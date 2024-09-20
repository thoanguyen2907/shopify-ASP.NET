using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.src.Entity;

namespace Shopify.src.Service
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}