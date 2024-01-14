using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.src.Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Inventory { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public override string ToString()
        {
            return $"Product Id: {Id}, Name: {Name}, Description: {Description}, Price: {Price}, Inventory: {Inventory}, CategoryId: {CategoryId}";
        }
    }

}