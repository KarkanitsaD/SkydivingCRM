using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using SkydivingCRM.AuthService.Business.Models;
using SkydivingCRM.AuthService.Business.Services.IServices;

namespace SkydivingCRM.AuthService.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        public async Task<SuccessLoginModel> LoginAsync(LoginModel loginModel)
        {
            var client = _httpClientFactory.CreateClient("IdentityServerClient");
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                throw new Exception("IS4 not allowed now!");
            }

            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "client",

                ClientSecret = "secret",

                Scope = "SkydivingCRM.API IdentityServerApi",

                GrantType = "password",

                UserName = loginModel.Username,

                Password = loginModel.Password
            });


            if (tokenResponse.IsError)
            {
                throw new Exception("Not authorized");
            }

            return new SuccessLoginModel
            {
                AccessToken = tokenResponse.AccessToken
            };
        }
    }
}