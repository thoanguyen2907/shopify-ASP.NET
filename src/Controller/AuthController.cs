using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        [HttpPost("validate-google-token")]
        public async Task<IActionResult> ValidateGoogleToken([FromBody] string token)
        {
            var payload = await _authService.ValidateGoogleToken(token);
            if (payload == null)
            {
                return Unauthorized("Invalid Google Token");
            }
            var email = payload.Email;
            var name = payload.Name;

            var isNewUser = await _authService.HandleUserLogin(email, name);
            return Ok(new { isNewUser });
        }


    }
}