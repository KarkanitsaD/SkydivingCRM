using System.Threading.Tasks;
using SkydivingCRM.UserService.Business.Models.Auth;
using SkydivingCRM.UserService.Business.Models.User;

namespace SkydivingCRM.UserService.Business.Services.IServices
{
    public interface IAuthService
    {
        Task RegisterDirector(UserModel director, string password);

        Task<string> Login(LoginModel loginModel);
    }
}