using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shopify.src.Abstraction;
using Shopify.src.DTO;
using Shopify.src.Entity;
using Shopify.src.Repository;
using Shopify.src.Shared;

namespace Shopify.src.Service.Impl
{
    public class UserService : IUserService
    {
        protected IBaseRepo<User> _userRepo;
        protected IMapper _mapper;

        public UserService(IBaseRepo<User> userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }
        public async Task<UserReadDto> CreateOneAsync(UserCreateDto createDto)
        {
            var user = _mapper.Map<UserCreateDto, User>(createDto);
            user.Role = Role.Customer;
            var savedUser = await _userRepo.CreateOneAsync(user);
            return _mapper.Map<User, UserReadDto>(savedUser);
        }

        public async Task<bool> DeleteOneAsync(Guid id)
        {
            var foundUser = await _userRepo.GetByIdAsync(id);
            if (foundUser is not null)
            {
                return await _userRepo.DeleteOneAsync(foundUser);
            }
            return false;
        }

        public async Task<IEnumerable<UserReadDto>> GetAllAsync(GetAllOptions getAllOptions)
        {
            var userList = await _userRepo.GetAllAsync(getAllOptions);
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserReadDto>>(userList);
        }

        public async Task<UserReadDto> GetByIdAsync(Guid id)
        {
            var foundUser = await _userRepo.GetByIdAsync(id);
            if (foundUser is null)
            {
                throw new Exception("user is not found");
            }
            return _mapper.Map<User, UserReadDto>(foundUser);
        }

        public async Task<bool> UpdateOneAsync(Guid id, UserUpdateDto updateDto)
        {
            var foundItem = await _userRepo.GetByIdAsync(id) ?? throw new Exception("User is not found");
            Console.WriteLine(foundItem);
            // var properties = updateDto!.GetType().GetProperties(); 
            // foreach (var p in properties)
            // {
            //     if (p.GetValue(foundItem) is not null && p.GetValue(updateDto) is null)
            //     {
            //         p.SetValue(updateDto, p.GetValue(foundItem));
            //     }
            // }
            if (foundItem == null)
            {
                return false;
            }

           //  var user = _mapper.Map<UserUpdateDto, User>(updateDto);
            _mapper.Map(updateDto, foundItem);

            return await _userRepo.UpdateOneAsync(foundItem);
        }
    }
}