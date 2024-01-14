using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.src.Abstraction;
using Shopify.src.Shared;

namespace Shopify.src.Service.Impl
{
    public class AuthService : IAuthService
    {
        private IUserRepo _userRepo;
        private ITokenService _tokenService;
        public AuthService(IUserRepo userRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }
        public async Task<string> Login(Credentials credentials)
        {
            var foundByEmail = await _userRepo.FindByEmailAsync(credentials.Email);
            if (foundByEmail is null)
            {
                throw CustomException.UnAuthorized();
            }
            var passwordMatched = PasswordService.VerifyPassword(credentials.Password, foundByEmail.Password, foundByEmail.Salt);
            if (passwordMatched)
            {
                return _tokenService.GenerateToken(foundByEmail);
            }
            throw CustomException.UnAuthorized();
        }
    }
}