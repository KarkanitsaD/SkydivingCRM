using System;
using System.Threading.Tasks;
using SkydivingCRM.UserService.Business.Models.Auth;
using SkydivingCRM.UserService.Business.Models.User;

namespace SkydivingCRM.UserService.Business.Services.IServices
{
    public interface IAuthService
    {
        Task ConfirmEmailAsync(Guid userId, string code);

        Task RegisterClubAdministrator(UserModel admin, string password);

        Task<string> Login(LoginModel loginModel);

        Task ConfirmEmail(Guid userId, string code);
    }
}