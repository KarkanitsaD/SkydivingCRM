using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using SkydivingCRM.AuthCommon;

namespace SkydivingCRM.UserService.Api.IdentityServer4
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>
        {

            //Api resources: SkydivingCRM.API - all services related to application except UserService
            //               IdentityServerConstants.LocalApi.ScopeName - IdentityServer endpoints
            new ("SkydivingCRM.API", "SkydivingCRM.API", new []
            {
                ClaimTypesConstants.EmailClaimType,
                ClaimTypesConstants.IdClaimType,
                ClaimTypesConstants.NameClaimType,
                ClaimTypesConstants.PatronymicClaimType,
                ClaimTypesConstants.SurnameClaimType,
                ClaimTypesConstants.RoleClaimType
            }),

            new (IdentityServerConstants.LocalApi.ScopeName)
        };


        //Clients: because of all services are first-party applications - i have one client on all
        //with to allowed resources: SkydivingCRM.API, IdentityServerConstants.LocalApi.ScopeName
        public static IEnumerable<Client> Clients => new List<Client>
        {
            new ()
            {
                ClientId = "client",

                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                ClientSecrets = {new Secret("secret".Sha256())},

                AllowedScopes = { "SkydivingCRM.API", IdentityServerConstants.LocalApi.ScopeName},

                AccessTokenLifetime = 86400
            }
        };
    }
}