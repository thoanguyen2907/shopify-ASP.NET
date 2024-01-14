using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.src.Shared;

namespace Shopify.src.Service
{
    public interface IAuthService
    {
        Task<string> Login(Credentials credentials);
    }
}