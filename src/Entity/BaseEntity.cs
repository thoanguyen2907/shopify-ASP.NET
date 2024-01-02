using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.src.Entity
{
    public class BaseEntity : TimeStamp
    {
        public Guid Id {get; set;} 
    }
}