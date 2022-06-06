using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkydivingCRM.AuthService.Business.Options;

namespace SkydivingCRM.AuthService.Api.Extensions
{
    public static class HttpClientsExtensions
    {
        public static void AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("IdentityServerClient",
                c =>
                {
                    c.BaseAddress = new Uri(configuration.GetSection(nameof(IdentityServerOptions)).Get<IdentityServerOptions>().Location);
                });
        }
    }
}