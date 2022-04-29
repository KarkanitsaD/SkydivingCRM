using AutoMapper;
using SkydivingCRM.SkydivingClubService.Api.Models.RequestModels.SkydivingClub;
using SkydivingCRM.SkydivingClubService.Business.Models.SkydivingClub;
using SkydivingCRM.SkydivingClubService.Business.Models.User;
using SkydivingCRM.SkydivingClubService.Data.Entities;

namespace SkydivingCRM.SkydivingClubService.Api.MappingProfiles
{
    public class SkydivingClubMappingProfile : Profile
    {
        public SkydivingClubMappingProfile()
        {
            CreateMap<SkydivingClubEntity, SkydivingClubModel>().ReverseMap();

            CreateMap<RegisterSkydivingClubRequestModel, SkydivingClubModel>();

            CreateMap<UpdateSkydivingClubRequestModel, SkydivingClubModel>();

            CreateMap<RegisterSkydivingClubRequestModel, UserModel>()
                .ForMember(src => src.Email, act => act.MapFrom(dest => dest.ClubAdministratorEmail))
                .ForMember(src => src.Login, act => act.MapFrom(dest => dest.ClubAdministratorLogin))
                .ForMember(src => src.Name, act => act.MapFrom(dest => dest.ClubAdministratorName))
                .ForMember(src => src.Surname, act => act.MapFrom(dest => dest.ClubAdministratorSurname))
                .ForMember(src => src.Patronymic, act => act.MapFrom(dest => dest.ClubAdministratorPatronymic));
        }
    }
}