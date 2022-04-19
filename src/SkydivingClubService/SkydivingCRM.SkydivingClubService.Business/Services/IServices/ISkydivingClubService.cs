using System;
using System.Threading.Tasks;
using SkydivingCRM.SkydivingClubService.Business.Models;
using SkydivingCRM.SkydivingClubService.Business.Models.SkydivingClub;
using SkydivingCRM.SkydivingClubService.Business.Models.User;

namespace SkydivingCRM.SkydivingClubService.Business.Services.IServices
{
    public interface ISkydivingClubService
    {
        Task<SkydivingClubModel> GetSkydivingClub(Guid clubId);

        Task<SkydivingClubModel> RegisterSkydivingClub(SkydivingClubModel skydivingClubModel, UserModel director, string password);

        Task<SkydivingClubModel> UpdateSkydivingClub(SkydivingClubModel skydivingClubModel);
    }
}