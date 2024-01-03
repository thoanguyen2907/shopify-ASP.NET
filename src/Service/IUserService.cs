using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.src.DTO;
using Shopify.src.Shared;

namespace Shopify.src.Service
{
    public interface IUserService
    {
        Task<UserReadDto> CreateOneAsync(UserCreateDto createDto);
        Task<bool> DeleteOneAsync(Guid id);
        Task<IEnumerable<UserReadDto>> GetAllAsync(GetAllOptions getAllOptions);
        Task<UserReadDto> GetByIdAsync(Guid id);
        Task<bool> UpdateOneAsync(Guid id, UserUpdateDto updateDto);
    }
}