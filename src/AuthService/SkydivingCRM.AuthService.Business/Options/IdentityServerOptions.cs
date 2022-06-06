namespace SkydivingCRM.AuthService.Business.Options
{
    public class IdentityServerOptions
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string GrantType { get; set; }

        public string Scope { get; set; }

        public string Location { get; set; }
    }
}