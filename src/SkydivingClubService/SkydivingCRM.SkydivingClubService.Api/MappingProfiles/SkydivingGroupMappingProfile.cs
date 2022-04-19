using AutoMapper;
using SkydivingCRM.SkydivingClubService.Business.Models;
using SkydivingCRM.SkydivingClubService.Business.Models.SkydivingGroup;
using SkydivingCRM.SkydivingClubService.Data.Entities;

namespace SkydivingCRM.SkydivingClubService.Api.MappingProfiles
{
    public class SkydivingGroupMappingProfile : Profile
    {
        public SkydivingGroupMappingProfile()
        {
            CreateMap<SkydivingGroupEntity, SkydivingGroupModel>()
                .ReverseMap();
        }
    }
}