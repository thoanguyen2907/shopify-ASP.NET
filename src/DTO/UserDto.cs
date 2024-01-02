using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.src.Entity;

namespace Shopify.src.DTO
{
    public class UserReadDto : BaseEntity
    {
        public string Name {get; set;}
        public string Email {get; set;}
        public Role Role {get; set;}
    }
    public class UserCreateDto 
    {
        public string Name {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
    }
    public class UserUpdateDto
    {
        public string? Name {get; set;}
        public string? Email {get; set;}
        public string? Password {get; set;}
    }
}