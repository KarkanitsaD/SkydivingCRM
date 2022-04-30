using AutoMapper;
using SkydivingCRM.SkydivingClubService.Business.Models.Equipment;
using SkydivingCRM.SkydivingClubService.Data.Entities;

namespace SkydivingCRM.SkydivingClubService.Api.MappingProfiles
{
    public class EquipmentMapperProfile : Profile
    {
        public EquipmentMapperProfile()
        {
            CreateMap<EquipmentEntity, EquipmentModel>().ReverseMap();
        }
    }
}