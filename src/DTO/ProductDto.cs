using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.src.Entity;

namespace Shopify.src.DTO
{
    public class ProductReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Inventory { get; set; }
        public CategoryReadDto Category { get; set; }
    }
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Inventory { get; set; }
        public Guid CategoryId { get; set; }
    }
    public class ProductUpdateDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? Inventory { get; set; }
        public Guid? CategoryId { get; set; }
          public override string ToString()
        {
            return $"Product  Name: {Name}, Description: {Description}, Price: {Price}, Inventory: {Inventory}, CategoryId: {CategoryId}";
        }
    }
}