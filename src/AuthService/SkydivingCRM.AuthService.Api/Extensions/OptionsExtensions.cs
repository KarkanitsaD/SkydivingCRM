using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkydivingCRM.AuthService.Business.Options;

namespace SkydivingCRM.AuthService.Api.Extensions
{
    public static class OptionsExtensions
    {
        public static void AddOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IdentityServerOptions>(configuration.GetSection(nameof(IdentityServerOptions)));
        }
    }
}