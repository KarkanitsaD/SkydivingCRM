using Microsoft.Extensions.DependencyInjection;
using SkydivingCRM.UserService.Data.Repositories;
using SkydivingCRM.UserService.Data.Repositories.IRepositories;

namespace SkydivingCRM.UserService.Api.Extensions
{
    public static class RepositoriesExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISkydivingGroupSportsmanRepository, SkydivingGroupSportsmanRepository>();
            services.AddScoped<ISkydivingGroupInstructorRepository, SkydivingGroupInstructorRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}