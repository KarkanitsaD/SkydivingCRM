using System.Threading.Tasks;
using SkydivingCRM.AuthService.Business.Models;

namespace SkydivingCRM.AuthService.Business.Services.IServices
{
    public interface IAuthService
    {
        Task<SuccessLoginModel> LoginAsync(LoginModel loginModel);
    }
}