using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopify.src.DTO;
using Shopify.src.Service;
using Shopify.src.Shared;

namespace Shopify.src.Controller
{
    public class ProductController : BaseController
    {
        protected readonly IProductService _productService;
        private readonly IConfiguration _config;
        public ProductController(IProductService service, IConfiguration config)
        {
            _productService = service;
            _config = config;
        }

        [HttpPost()]
        public async Task<ActionResult<ProductReadDto>> CreateOneAsync([FromBody] ProductCreateDto createDto)
        {

            var product = await _productService.CreateOneAsync(createDto);
            return Ok(product);
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAllAsync([FromQuery] GetAllOptions getAllOptions)
        {
            // var authenticatedClaims = HttpContext.User;
            // var userId = authenticatedClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

            var productList = await _productService.GetAllAsync(getAllOptions);
            return Ok(productList);
        }

        [HttpGet("category/{id:guid}")]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAllByCategoryIdAsync(Guid id, [FromQuery] GetAllOptions getAllOptions)
        {
            var productList = await _productService.GetProductsByCategoryIdAsync(id, getAllOptions);
            return Ok(productList);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<bool>> DeleteOneAsync([FromRoute] Guid id)
        {
            var deleted = await _productService.DeleteOneAsync(id);
            return Ok(deleted);
        }

        [HttpPatch("{id:guid}")]
        public async Task<ActionResult<bool>> UpdateOneAsync([FromRoute] Guid id, [FromBody] ProductUpdateDto updateDto)
        {
            var updated = await _productService.UpdateOneAsync(id, updateDto);
            return Ok(updated);
        }
    }
}