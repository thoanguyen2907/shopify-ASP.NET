using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Shopify.src.Entity;

namespace Shopify.src.Service.Impl
{
    public class TokenService : ITokenService
    {
        private IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateToken(User user)
        {
            var issuer = _config.GetSection("Jwt:Issuer").Value;
            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var audience = _config.GetSection("Jwt:Audience").Value;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value!));
            var signingKey = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                Expires = DateTime.Now.AddDays(2),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = signingKey
            };
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}