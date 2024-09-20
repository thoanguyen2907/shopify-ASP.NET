using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Auth;
using Shopify.src.Abstraction;
using Shopify.src.Entity;
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

        public async Task<bool> HandleUserLogin(string email, string name)
        {
            var user = await _userRepo.FindByEmailAsync(email);
            if (user == null)
            {
                var dummyPassword = "DummyPassword123!";
                PasswordService.HashPassword(dummyPassword, out string hashedPassword, out byte[] salt);
                var newUser = new User
                {
                    Email = email,
                    Name = name,
                    IsOauth = true,
                    Password = hashedPassword,
                    Salt = salt
                };
                await _userRepo.CreateOneAsync(newUser);
                return true;
            }
            return false;
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

        public async Task<GoogleJsonWebSignature.Payload> ValidateGoogleToken(string token)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { "777778582585-23gqf417u1g7anc13vp6j3ffn5ac6dc9.apps.googleusercontent.com" }
                };
                var payload = await GoogleJsonWebSignature.ValidateAsync(token, settings);
                return payload;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}