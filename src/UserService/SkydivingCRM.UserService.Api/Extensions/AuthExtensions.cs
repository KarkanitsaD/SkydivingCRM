﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SkydivingCRM.AuthCommon;

namespace SkydivingCRM.UserService.Api.Extensions
{
    public static class AuthExtensions
    {
        public static void AddAuthorizationService(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(PoliciesConstants.ClubAdministrator, policy =>
                {
                    policy.RequireRole(RolesConstants.ClubAdministratorRole);
                });

                options.AddPolicy(PoliciesConstants.Instructor, policy =>
                {
                    policy.RequireRole(RolesConstants.InstructorRole);
                });

                options.AddPolicy(PoliciesConstants.Sportsman, policy =>
                {
                    policy.RequireRole(RolesConstants.SportsmanRole);
                });
            });
        }
    }
}