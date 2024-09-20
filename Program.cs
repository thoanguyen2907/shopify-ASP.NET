using Shopify.src.Database;
using AutoMapper;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Shopify.src.Service;
using Shopify.src.Service.Impl;
using Shopify.src.Entity;
using Shopify.src.Abstraction;
using Shopify.src.Repository;
using Shopify.src.Shared;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Swashbuckle.AspNetCore.Filters;
using Shopify.src.Middleware;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
     options =>
    {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Description = "Bearer token authentication",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Scheme = "Bearer"
        }
        );

        options.OperationFilter<SecurityRequirementsOperationFilter>();
    }
);

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

builder.Services.AddScoped<ExceptionHandlerMiddleware>();

// add DI services
builder.Services
    .AddScoped<IUserService, UserService>()
    .AddScoped<ICategoryService, CategoryService>()
    .AddScoped<IProductService, ProductService>()
    .AddScoped<IAuthService, AuthService>()
    .AddScoped<ITokenService, TokenService>()
    .AddScoped<IOrderService, OrderService>()
    .AddScoped<IOrderDetailService, OrderDetailService>();

builder.Services
    .AddScoped<IUserRepo, UserRepo>()
    .AddScoped<ICategoryRepo, CategoryRepo>()
    .AddScoped<IProductRepo, ProductRepo>()
    .AddScoped<IOrderRepo, OrderRepo>()
    .AddScoped<IOrderDetailRepo, OrderDetailRepo>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                      });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    }
);

builder.Services.AddAuthorization();

// app build 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add middlewares
app.UseCors(MyAllowSpecificOrigins);

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


