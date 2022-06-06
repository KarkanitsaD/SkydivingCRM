using Microsoft.IdentityModel.Tokens;

namespace SkydivingCRM.AuthCommon
{
    public class AuthOptions
    {
        public string SecretKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string TokenLifeTimeInSeconds { get; set; }

        public SymmetricSecurityKey SymmetricSecurityKey =>
            new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(SecretKey));
    }
}
