using AutoMapper;
using SkydivingCRM.UserService.Api.Models.RequestModels.User;
using SkydivingCRM.UserService.Business.Models.Auth;

namespace SkydivingCRM.UserService.Api.MappingProfiles
{
    public class AuthMapperProfile : Profile
    {
        public AuthMapperProfile()
        {
            CreateMap<LoginUserRequestModel, LoginModel>();
        }
    }
}