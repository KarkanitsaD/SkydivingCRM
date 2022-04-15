using AutoMapper;
using SkydivingCRM.UserService.Api.Models.RequestModels;
using SkydivingCRM.UserService.Api.Models.RequestModels.User;
using SkydivingCRM.UserService.Api.Models.ResponseModels;
using SkydivingCRM.UserService.Business.Models.User;
using SkydivingCRM.UserService.Data.Entities;

namespace SkydivingCRM.UserService.Api.MappingProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserEntity, UserModel>();
            CreateMap<UserModel, RegisterUserResponseModel>();
            CreateMap<RegisterUserRequestModel, UserModel>();
        }
    }
}