using System.Threading.Tasks;
using SkydivingCRM.UserService.Business.Models;
using SkydivingCRM.UserService.Business.Models.User;

namespace SkydivingCRM.UserService.Business.Services.IServices
{
    public interface IUserService
    {
        Task<UserModel> RegisterInstructor(UserModel instructor, string password);

        Task<UserModel> RegisterSportsman(UserModel sportsman, string password);

        Task AddSportsmanToGroup(SkydivingGroupSportsmanModel model);

        Task AddInstructorToGroup(SkydivingGroupInstructorModel model);
    }
}