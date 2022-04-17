using AutoMapper;
using SkydivingCRM.UserService.Api.Models.RequestModels.User;
using SkydivingCRM.UserService.Api.Models.ResponseModels;
using SkydivingCRM.UserService.Api.Models.ResponseModels.User;
using SkydivingCRM.UserService.Business.Models.User;
using SkydivingCRM.UserService.Data.Entities;

namespace SkydivingCRM.UserService.Api.MappingProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserModel, UserEntity>()
                .ForMember(src => src.UserName, act => act.MapFrom(dest => dest.Email));
            CreateMap<UserEntity, UserModel>();
            CreateMap<UserModel, RegisterUserResponseModel>();
            CreateMap<RegisterUserRequestModel, UserModel>();
        }
    }
}