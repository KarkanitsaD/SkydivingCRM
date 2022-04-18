using Microsoft.IdentityModel.Tokens;

namespace SkydivingCRM.UserService.Business.Options
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string TokenLifeTimeInSeconds { get; set; }

        public SymmetricSecurityKey SymmetricSecurityKey =>
            new (System.Text.Encoding.ASCII.GetBytes(SecretKey));
    }
}