using Microsoft.Extensions.DependencyInjection;
using SkydivingCRM.AuthService.Business.Services.IServices;

namespace SkydivingCRM.AuthService.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, Business.Services.AuthService>();
        }
    }
}