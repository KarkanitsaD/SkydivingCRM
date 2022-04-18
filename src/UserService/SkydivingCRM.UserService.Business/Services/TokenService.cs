using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SkydivingCRM.UserService.Business.Constants;
using SkydivingCRM.UserService.Business.Models.User;
using SkydivingCRM.UserService.Business.Options;
using SkydivingCRM.UserService.Business.Services.IServices;

namespace SkydivingCRM.UserService.Business.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtOptions _jwtOptions;

        public TokenService(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public string GenerateJwtAsync(UserModel userModel)
        {
            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                expires: DateTime.Now.AddSeconds(double.Parse(_jwtOptions.TokenLifeTimeInSeconds)),
                signingCredentials: new SigningCredentials(_jwtOptions.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature),
                claims: GetClaims(userModel)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private List<Claim> GetClaims(UserModel user)
        {
            var claims = new List<Claim>
            {
                new (ClaimTypesConstants.IdClaimType, user.Id.ToString()),
                new (ClaimTypesConstants.NameClaimType, user.Name),
                new (ClaimTypesConstants.PatronymicClaimType, user.Patronymic),
                new (ClaimTypesConstants.SurnameClaimType, user.Surname),
                new (ClaimTypesConstants.EmailClaimType, user.Email)
            };

            var roleClaims = user.Roles.Select(role => 
                new Claim(ClaimTypesConstants.RolesClaimType, role));

            claims.AddRange(roleClaims);

            return claims;
        }
    }
}