using AutoMapper;
using SkydivingCRM.UserService.Business.Models.Role;
using SkydivingCRM.UserService.Data.Entities;

namespace SkydivingCRM.UserService.Api.MappingProfiles
{
    public class RoleMapperProfile : Profile
    {
        public RoleMapperProfile()
        {
            CreateMap<RoleEntity, RoleModel>().ReverseMap();
        }
    }
}