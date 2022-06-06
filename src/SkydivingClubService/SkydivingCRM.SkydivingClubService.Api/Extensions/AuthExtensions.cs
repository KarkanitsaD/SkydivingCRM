using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SkydivingCRM.AuthCommon;

namespace SkydivingCRM.SkydivingClubService.Api.Extensions
{
    public static class AuthExtensions
    {
        public static void AddIdentityServerAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5001";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
        }

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