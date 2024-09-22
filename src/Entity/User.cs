using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shopify.src.Entity
{
    public class User : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public byte[] Salt { get; set; }
        public bool IsOauth { get; set; }
        public string Image { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        Admin,
        Customer
    }
}