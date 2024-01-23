using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.src.Entity
{
    public class OrderDetail : BaseEntity
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }

        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }

        public override string ToString()
        {
            return $"OrderDetail ID: {Id}, Quantity: {Quantity}, Product ID: {ProductId}, Order ID: {OrderId}";
        }

    }
}