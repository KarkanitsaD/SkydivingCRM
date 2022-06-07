using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SkydivingCRM.AuthCommon;
using SkydivingCRM.UserService.Business.Models.User;
using SkydivingCRM.UserService.Business.Services.IServices;

namespace SkydivingCRM.UserService.Business.Services
{
    public class TokenService : ITokenService
    {
        private readonly AuthOptions _jwtOptions;

        public TokenService(IOptions<AuthOptions> jwtOptions)
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

        public List<Claim> GetClaims(UserModel user)
        {
            var claims = new List<Claim>
            {
                new (ClaimTypesConstants.IdClaimType, user.Id.ToString())
            };

            if (user.Name != null)
            {
                claims.Add(new(ClaimTypesConstants.NameClaimType, user.Name));
            }

            if (user.Surname != null)
            {
                claims.Add(new(ClaimTypesConstants.SurnameClaimType, user.Surname));
            }
            if (user.Patronymic != null)
            {
                claims.Add(new Claim(ClaimTypesConstants.PatronymicClaimType, user.Patronymic));
            }
            if (user.Email != null)
            {
                claims.Add(new Claim(ClaimTypesConstants.EmailClaimType, user.Email));
            }

            var roleClaims = user.Roles.Select(role => 
                new Claim(ClaimTypesConstants.RoleClaimType, role));

            claims.AddRange(roleClaims);

            return claims;
        }
    }
}