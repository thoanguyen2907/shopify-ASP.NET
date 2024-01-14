using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopify.src.Service;
using Shopify.src.Shared;

namespace Shopify.src.Controller
{
    public class AuthController : BaseController
    {
        private IAuthService _authService;
        public AuthController(IAuthService service)
        {
            _authService = service;
        }
        [HttpPost()]
        public async Task<ActionResult<string>> Login([FromBody] Credentials credentials)
        {
            var token = await _authService.Login(credentials);
            return Ok(token);
        }
    }
}