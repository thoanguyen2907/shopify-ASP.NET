using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopify.src.DTO;
using Shopify.src.Service;
using Shopify.src.Shared;

namespace Shopify.src.Controller
{
    public class UserController : BaseController
    {
        protected readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost()]
        public async Task<ActionResult<UserReadDto>> CreateOneAsync([FromBody] UserCreateDto userCreateDto)
        {
            var user = await _userService.CreateOneAsync(userCreateDto);
            return Ok(user);
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAllAsync([FromQuery] GetAllOptions getAllOptions)
        {
            var userList = await _userService.GetAllAsync(getAllOptions);
            return Ok(userList);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserReadDto>> GetByIdAsync([FromRoute] Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<bool>> DeleteOneAsync([FromRoute] Guid id)
        {
            var deleted = await _userService.DeleteOneAsync(id);
            return Ok(deleted);
        }

        [HttpPatch("{id:guid}")]
        public async Task<ActionResult<bool>> UpdateOneAsync([FromRoute] Guid id, [FromBody] UserUpdateDto updateDto)
        {
            var updated = await _userService.UpdateOneAsync(id, updateDto);
            return Ok(updated);
        }
    }
}