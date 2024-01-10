using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shopify.src.DTO;
using Shopify.src.Entity;

namespace Shopify.src.Shared
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>()
                       .ForAllMembers(opts => opts.Condition((src, dest, srcProperty) => srcProperty != null));

            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>()
                       .ForAllMembers(opts => opts.Condition((src, dest, srcProperty) => srcProperty != null));

            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>()
                        .ForMember(dest => dest.CategoryId, opt => opt.MapFrom((src, dest, destMember, context) => src.CategoryId ?? destMember))
                        .ForAllMembers(opts => opts.Condition((src, dest, srcProperty) =>
                        {
                            Console.WriteLine($"Mapping to {dest.GetType().Name}.{opts.DestinationMember.Name}");
                            return srcProperty != null;
                        }));
        }
    }
}