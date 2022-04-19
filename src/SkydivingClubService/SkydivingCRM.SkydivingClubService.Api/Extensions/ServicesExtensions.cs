using Microsoft.Extensions.DependencyInjection;
using SkydivingCRM.SkydivingClubService.Business.Services.IServices;

namespace SkydivingCRM.SkydivingClubService.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISkydivingClubService, Business.Services.SkydivingClubService>();
        }
    }
}