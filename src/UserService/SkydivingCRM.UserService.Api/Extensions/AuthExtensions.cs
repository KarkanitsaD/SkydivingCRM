using Microsoft.Extensions.DependencyInjection;
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