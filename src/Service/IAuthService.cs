using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Auth;
using Shopify.src.Shared;

namespace Shopify.src.Service
{
    public interface IAuthService
    {
        Task<string> Login(Credentials credentials);
        Task<bool> HandleUserLogin(string email, string name);
        Task<GoogleJsonWebSignature.Payload> ValidateGoogleToken(string token);
    }
}