using SkydivingCRM.UserService.Business.Models.User;

namespace SkydivingCRM.UserService.Business.Services.IServices
{
    public interface ITokenService
    {
        string GenerateJwtAsync(UserModel userModel);
    }
}