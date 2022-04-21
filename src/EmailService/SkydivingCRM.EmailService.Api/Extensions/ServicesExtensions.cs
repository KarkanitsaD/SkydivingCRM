using Microsoft.Extensions.DependencyInjection;
using SkydivingCRM.EmailService.Business.Services.IServices;

namespace SkydivingCRM.EmailService.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, Business.Services.EmailService>();
        }
    }
}