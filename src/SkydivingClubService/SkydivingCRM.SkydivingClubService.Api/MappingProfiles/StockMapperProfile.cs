using AutoMapper;
using SkydivingCRM.SkydivingClubService.Business.Models.Stock;
using SkydivingCRM.SkydivingClubService.Data.Entities;

namespace SkydivingCRM.SkydivingClubService.Api.MappingProfiles
{
    public class StockMapperProfile : Profile
    {
        public StockMapperProfile()
        {
            CreateMap<StockEntity, StockModel>().ReverseMap();
        }
    }
}