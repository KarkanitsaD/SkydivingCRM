using AutoMapper;
using SkydivingCRM.SkydivingClubService.Business.Models;
using SkydivingCRM.SkydivingClubService.Business.Models.City;
using SkydivingCRM.SkydivingClubService.Data.Entities;

namespace SkydivingCRM.SkydivingClubService.Api.MappingProfiles
{
    public class CityMappingProfile : Profile
    {
        public CityMappingProfile()
        {
            CreateMap<CityEntity, CityModel>()
                .ReverseMap();
        }
    }
}