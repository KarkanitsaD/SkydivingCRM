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

            CreateMap<RegisterSkydivingClubRequestModel, UserModel>()
                .ForMember(src => src.Email, act => act.MapFrom(dest => dest.DirectorEmail))
                .ForMember(src => src.Login, act => act.MapFrom(dest => dest.DirectorLogin))
                .ForMember(src => src.Name, act => act.MapFrom(dest => dest.DirectorName))
                .ForMember(src => src.Surname, act => act.MapFrom(dest => dest.DirectorSurname))
                .ForMember(src => src.Patronymic, act => act.MapFrom(dest => dest.DirectorPatronymic));
        }
    }
}