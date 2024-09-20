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
    public class OrderDetailController : BaseController
    {
        protected readonly IOrderDetailService _orderDetailService; 
        public OrderDetailController(IOrderDetailService service)
        {
            _orderDetailService = service; 
        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<OrderDetailReadDto>>> GetAllAsync([FromQuery] GetAllOptions getAllOptions)
        {
        
            var productList = await _orderDetailService.GetAllAsync(getAllOptions);
            return Ok(productList);
        }
    }
}