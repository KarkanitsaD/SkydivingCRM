using Microsoft.Extensions.DependencyInjection;
using SkydivingCRM.SkydivingClubService.Data.Repositories;
using SkydivingCRM.SkydivingClubService.Data.Repositories.IRepositories;

namespace SkydivingCRM.SkydivingClubService.Api.Extensions
{
    public static class RepositoriesExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISkydivingClubRepository, SkydivingClubRepository>();
        }
    }
}