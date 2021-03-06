using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SkydivingCRM.SkydivingClubService.Api.MappingProfiles;

namespace SkydivingCRM.SkydivingClubService.Api.Extensions
{
    public static class MappingProfilesExtensions
    {
        public static void AddMappingProfiles(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new SkydivingClubMappingProfile());
                cfg.AddProfile(new SkydivingGroupMappingProfile());
                cfg.AddProfile(new StockMapperProfile());
                cfg.AddProfile(new EquipmentMapperProfile());
            }).CreateMapper());
        }
    }
}