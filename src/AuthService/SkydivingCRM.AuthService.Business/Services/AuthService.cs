using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using SkydivingCRM.AuthService.Business.Models;
using SkydivingCRM.AuthService.Business.Options;
using SkydivingCRM.AuthService.Business.Services.IServices;

namespace SkydivingCRM.AuthService.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IdentityServerOptions _identityServerOptions;

        public AuthService(IHttpClientFactory clientFactory, IOptions<IdentityServerOptions> options)
        {
            _httpClientFactory = clientFactory;
            _identityServerOptions = options.Value;
        }

        public async Task<SuccessLoginModel> LoginAsync(LoginModel loginModel)
        {
            var client = _httpClientFactory.CreateClient("IdentityServerClient");
            var disco = await client.GetDiscoveryDocumentAsync();
            if (disco.IsError)
            {
                throw new Exception("IS4 not allowed now!");
            }

            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = _identityServerOptions.ClientId,

                ClientSecret = _identityServerOptions.ClientSecret,

                Scope = _identityServerOptions.Scope,

                GrantType = _identityServerOptions.GrantType,

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