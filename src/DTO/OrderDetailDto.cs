using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.src.DTO
{
    public class OrderDetailCreateDto
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
    public class OrderDetailReadDto
    {
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public ProductReadDto Product { get; set; }
    }
}