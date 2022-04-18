using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SkydivingCRM.UserService.Api.MappingProfiles;

namespace SkydivingCRM.UserService.Api.Extensions
{
    public static class MappingProfilesExtensions
    {
        public static void AddMappingProfiles(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserMapperProfile());
                cfg.AddProfile(new AuthMapperProfile());
                cfg.AddProfile(new RoleMapperProfile());
            }).CreateMapper());
        }
    }
}