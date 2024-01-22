using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.src.Entity;
using Shopify.src.Shared;

namespace Shopify.src.Abstraction
{
    public interface IOrderRepo : IBaseRepo<Order>
    {
    }
}