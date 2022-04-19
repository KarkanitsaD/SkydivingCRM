using AutoMapper;
using SkydivingCRM.SkydivingClubService.Business.Models;
using SkydivingCRM.SkydivingClubService.Business.Models.Country;
using SkydivingCRM.SkydivingClubService.Data.Entities;

namespace SkydivingCRM.SkydivingClubService.Api.MappingProfiles
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<CountryEntity, CountryModel>()
                .ReverseMap();
        }
    }
}