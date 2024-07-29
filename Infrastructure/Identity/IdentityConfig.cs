namespace Infrastructure.Identity
{
    public class IdentityConfig
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
        public int TokenExpirationHours { get; set; }
    }
}