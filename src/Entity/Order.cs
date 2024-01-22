using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.src.Entity
{
    public class Order : BaseEntity
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }

        public override string ToString()
        {
            return $"Order ID: {Id}, User ID: {UserId}, Order Details Count: {OrderDetails?.Count()}";
        }
    }
}