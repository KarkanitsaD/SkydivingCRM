using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkydivingCRM.UserService.Business.Options;

namespace SkydivingCRM.UserService.Api.Extensions
{
    public static class OptionsExtensions
    {
        public static void AddJwtOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
        }
    }
}