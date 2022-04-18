using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SkydivingCRM.UserService.Business.Constants;

namespace SkydivingCRM.UserService.Api.AuthorizationHandlers
{
    public class RolesAuthorizationRequirement : IAuthorizationRequirement
    {
        public RolesAuthorizationRequirement(List<string> roles)
        {
            Roles = roles;
        }

        public List<string> Roles { get; set; }
    }

    public class RoleAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == ClaimTypesConstants.RolesClaimType))
            {
                var userRoles = context.User.Claims
                    .Where(c => c.Type == ClaimTypesConstants.RolesClaimType)
                    .Select(c => c.Value)
                    .ToList();

                foreach (var requiredRole in requirement.Roles)
                {
                    if (!userRoles.Contains(requiredRole))
                    {
                        return Task.CompletedTask;
                    }
                }
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}