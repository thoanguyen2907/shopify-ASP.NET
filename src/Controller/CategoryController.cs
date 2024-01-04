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
    public class CategoryController : BaseController
    {
        protected readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService service)
        {
            _categoryService = service;
        }

        [HttpPost()]
        public async Task<ActionResult<CategoryReadDto>> CreateOneAsync([FromBody] CategoryCreateDto createDto)
        {
            var categoryCreated = await _categoryService.CreateOneAsync(createDto);
            return Ok(categoryCreated);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryReadDto>>> GetAllAsync([FromQuery] GetAllOptions getAllOptions)
        {
            var categoryList = await _categoryService.GetAllAsync(getAllOptions);
            return Ok(categoryList);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoryReadDto>> GetByIdAsync([FromRoute] Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPatch("{id:guid}")]
        public async Task<ActionResult<bool>> UpdateOneAsync([FromRoute] Guid id, [FromBody] CategoryUpdateDto updateDto)
        {
            var updated = await _categoryService.UpdateOneAsync(id, updateDto);
            return Ok(updated);
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<bool>> DeleteOneAsync([FromRoute] Guid id)
        {
            var deleted = await _categoryService.DeleteOneAsync(id);
            return Ok(deleted);
        }
    }
}