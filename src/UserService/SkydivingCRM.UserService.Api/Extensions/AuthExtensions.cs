using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SkydivingCRM.UserService.Api.AuthorizationHandlers;
using SkydivingCRM.UserService.Business.Constants;
using SkydivingCRM.UserService.Business.Options;

namespace SkydivingCRM.UserService.Api.Extensions
{
    public static class AuthExtensions
    {
        public static void AddJwtBearerAuthentication(this IServiceCollection services, JwtOptions jwtOptions)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.Issuer,

                    ValidateAudience = true,
                    ValidAudience = jwtOptions.Audience,

                    ValidateLifetime = true,

                    IssuerSigningKey = jwtOptions.SymmetricSecurityKey,
                    ValidateIssuerSigningKey = true,

                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddAuthorizationHandlers(this IServiceCollection services)
        {
            services.AddTransient<IAuthorizationHandler, RoleAuthorizationHandler>();
        }

        public static void AddAuthorizationService(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(PoliciesConstants.ClubAdministrator, 
                    policy => policy.Requirements.Add(new RolesAuthorizationRequirement(new List<string>
                    {
                        RolesConstants.ClubAdministratorRole,
                    })));

                options.AddPolicy(PoliciesConstants.Instructor,
                    policy => policy.Requirements.Add(new RolesAuthorizationRequirement(new List<string>
                    {
                        RolesConstants.InstructorRole
                    })));

                options.AddPolicy(PoliciesConstants.Sportsman,
                    policy => policy.Requirements.Add(new RolesAuthorizationRequirement(new List<string>
                    {
                        RolesConstants.SportsmanRole
                    })));
            });
        }
    }
}