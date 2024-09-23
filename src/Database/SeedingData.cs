using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.src.Entity;
using Shopify.src.Service.Impl;


namespace Shopify.src.Database
{
    public class SeedingData
    {
        public static List<Category> GetCategories()
        {
            return new List<Category>
        {
            new Category { Id = Guid.Parse("1516cdd1-873e-49d0-a738-8319ca9da6fa"), Name = "Electronics" },
            new Category { Id = Guid.Parse("40bb3fbd-40b1-492f-b7fc-867ee12386d8"), Name = "Books" },
            new Category { Id = Guid.Parse("c57e98a6-0f06-42b0-8db3-e00c3bbf8a41"), Name = "Furniture" },
            new Category { Id = Guid.Parse("c6f620c2-5c40-4254-8cd1-4478711d5a65"), Name = "Clothing" },
            new Category { Id = Guid.Parse("1118eb3e-32b0-4510-b0a0-23f2d884c66f"), Name = "Toys" },
            new Category { Id = Guid.Parse("7d9e7704-cc3b-4647-8008-3836c21c7f92"), Name = "Groceries" },
            new Category { Id = Guid.Parse("bbb6d502-019b-4e32-839f-46f1c2fa5390"), Name = "Beauty & Personal Care" },
            new Category { Id = Guid.Parse("67f013b5-2bc3-46f9-8d79-a2eca059726c"), Name = "Sports & Outdoors" }
        };
        }

        public static List<Product> GetProducts()
        {
            return new List<Product>
        {
            new Product { Id = Guid.NewGuid(), Name = "Laptop", Description = "High-performance laptop", Price = 1200, Inventory = 50, CategoryId = Guid.Parse("1516cdd1-873e-49d0-a738-8319ca9da6fa") },
            new Product { Id = Guid.NewGuid(), Name = "Smartphone", Description = "Latest model smartphone", Price = 800, Inventory = 100, CategoryId = Guid.Parse("1516cdd1-873e-49d0-a738-8319ca9da6fa") },
            new Product { Id = Guid.NewGuid(), Name = "C# Programming", Description = "Comprehensive guide to C#", Price = 40, Inventory = 200, CategoryId = Guid.Parse("40bb3fbd-40b1-492f-b7fc-867ee12386d8") },
            new Product { Id = Guid.NewGuid(), Name = "ASP.NET Core Guide", Description = "Learn ASP.NET Core", Price = 50, Inventory = 150, CategoryId = Guid.Parse("40bb3fbd-40b1-492f-b7fc-867ee12386d8") },
            new Product { Id = Guid.NewGuid(), Name = "Sofa", Description = "Comfortable sofa", Price = 700, Inventory = 30, CategoryId = Guid.Parse("c57e98a6-0f06-42b0-8db3-e00c3bbf8a41") },
            new Product { Id = Guid.NewGuid(), Name = "T-shirt", Description = "Cotton t-shirt", Price = 20, Inventory = 300, CategoryId = Guid.Parse("c6f620c2-5c40-4254-8cd1-4478711d5a65") },
            new Product { Id = Guid.NewGuid(), Name = "Toy Car", Description = "Remote-controlled car", Price = 45, Inventory = 60, CategoryId = Guid.Parse("1118eb3e-32b0-4510-b0a0-23f2d884c66f") },
            new Product { Id = Guid.NewGuid(), Name = "Organic Apples", Description = "Fresh organic apples", Price = 5, Inventory = 500, CategoryId = Guid.Parse("7d9e7704-cc3b-4647-8008-3836c21c7f92") },
            new Product { Id = Guid.NewGuid(), Name = "Shampoo", Description = "Hair care shampoo", Price = 10, Inventory = 400, CategoryId = Guid.Parse("bbb6d502-019b-4e32-839f-46f1c2fa5390") },
            new Product { Id = Guid.NewGuid(), Name = "Tennis Racket", Description = "Professional tennis racket", Price = 120, Inventory = 70, CategoryId = Guid.Parse("67f013b5-2bc3-46f9-8d79-a2eca059726c") }
        };
        }
        public static List<User> GetUsers()
        {
            PasswordService.HashPassword("Alia!Admin@2024", out string hp, out byte[] salt);
            return new List<User>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Alice",
                    Email = "alice.ng@example.com",
                    Role = Role.Admin,
                    Password = hp,
                    Salt = salt,
                    Image = "https://png.pngtree.com/element_our/20200702/ourlarge/pngtree-girl-cute-cartoon-small-fresh-avatar-character-image_2297872.jpg"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nara",
                    Email = "nara.ng@example.com",
                    Role = Role.Customer,
                    Password = hp,
                    Salt = salt,
                    Image = "https://previews.123rf.com/images/danamayfay/danamayfay1909/danamayfay190900016/131686915-vector-female-character-in-cartoon-style-avatar-girl-in-a-circle-vector-illustration-isolated-on.jpg"
                }
            };
        }
        public static List<OrderDetail> GetOrderDetails()
        {
            var products = GetProducts(); // Assume GetProducts() returns the list of products generated earlier.

            return new List<OrderDetail>
{
    new OrderDetail { Id = Guid.NewGuid(), Quantity = 2, ProductId = products[0].Id, OrderId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
    new OrderDetail { Id = Guid.NewGuid(), Quantity = 1, ProductId = products[1].Id, OrderId = Guid.Parse("22222222-2222-2222-2222-222222222222") },
    new OrderDetail { Id = Guid.NewGuid(), Quantity = 3, ProductId = products[2].Id, OrderId = Guid.Parse("33333333-3333-3333-3333-333333333333") },
    new OrderDetail { Id = Guid.NewGuid(), Quantity = 4, ProductId = products[3].Id, OrderId = Guid.Parse("44444444-4444-4444-4444-444444444444") },
    new OrderDetail { Id = Guid.NewGuid(), Quantity = 1, ProductId = products[4].Id, OrderId = Guid.Parse("55555555-5555-5555-5555-555555555555") },
    new OrderDetail { Id = Guid.NewGuid(), Quantity = 5, ProductId = products[5].Id, OrderId = Guid.Parse("66666666-6666-6666-6666-666666666666") },
    new OrderDetail { Id = Guid.NewGuid(), Quantity = 2, ProductId = products[6].Id, OrderId = Guid.Parse("77777777-7777-7777-7777-777777777777") },
    new OrderDetail { Id = Guid.NewGuid(), Quantity = 6, ProductId = products[7].Id, OrderId = Guid.Parse("88888888-8888-8888-8888-888888888888") },
    new OrderDetail { Id = Guid.NewGuid(), Quantity = 7, ProductId = products[8].Id, OrderId = Guid.Parse("99999999-9999-9999-9999-999999999999") },
    new OrderDetail { Id = Guid.NewGuid(), Quantity = 1, ProductId = products[9].Id, OrderId = Guid.Parse("00000000-0000-0000-0000-000000000000") }
};

        }

        public static List<Order> GetOrders()
        {
            return new List<Order>
    {
        new Order { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), UserId = Guid.Parse("41273c5e-37bc-436e-a972-92efa09fa975") },
        new Order { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), UserId = Guid.Parse("41273c5e-37bc-436e-a972-92efa09fa975")},
        new Order { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), UserId = Guid.Parse("fc5546b0-4c9e-48da-a743-7c67aaaa6317")},
        new Order { Id = Guid.Parse("44444444-4444-4444-4444-444444444444") , UserId = Guid.Parse("fc5546b0-4c9e-48da-a743-7c67aaaa6317")},
        new Order { Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), UserId = Guid.Parse("41273c5e-37bc-436e-a972-92efa09fa975")}
    };
        }
    }
}
