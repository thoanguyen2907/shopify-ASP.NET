using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.src.DTO
{
    public class CategoryReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryUpdateDto
    {
        public string Name { get; set; }
    }
    public class CategoryCreateDto
    {
        [MinLength(5, ErrorMessage = "Name is too short, Min: 5 characters")]
        public string Name { get; set; }
    }
}