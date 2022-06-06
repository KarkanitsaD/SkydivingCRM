using System.Collections.Generic;
using System.Security.Claims;
using SkydivingCRM.UserService.Business.Models.User;

namespace SkydivingCRM.UserService.Business.Services.IServices
{
    public interface ITokenService
    {
        string GenerateJwtAsync(UserModel userModel);

        List<Claim> GetClaims(UserModel userModel);
    }
}