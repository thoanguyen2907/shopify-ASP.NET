using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.src.Entity;

namespace Shopify.src.DTO
{
    public class OrderCreateDto
    {
        public IEnumerable<OrderDetailCreateDto> OrderDetails { get; set; }
    }
    public class OrderReadDto
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<OrderDetailReadDto> OrderDetails {get; set;}
    }
}