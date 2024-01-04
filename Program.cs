using Shopify.src.Database;
using Shopify.src.Entity;
using AutoMapper;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Shopify.src.Shared;
using Shopify.src.Service;
using Shopify.src.Service.Impl;
using Shopify.src.Abstraction;
using Shopify.src.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add controllers
builder.Services.AddControllers();

// add database service
var dataSourceBuilder = new NpgsqlDataSourceBuilder(builder.Configuration.GetConnectionString("Local"));
dataSourceBuilder.MapEnum<Role>();
var dataSource = dataSourceBuilder.Build();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options
    .UseNpgsql(dataSource);
}
);
// add automapper service
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

// add DI services

builder.Services
    .AddScoped<IUserService, UserService>()
    .AddScoped<ICategoryService, CategoryService>()
    .AddScoped<IProductService, ProductService>()
    .AddScoped<IBaseRepo<User>, UserRepo>()
    .AddScoped<IBaseRepo<Category>, CategoryRepo>();
    .AddScoped<IBaseRepo<Product>, ProductRepo>();

// app build 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();



// Add middlewares
app.UseHttpsRedirection();
app.MapControllers();
app.Run();


