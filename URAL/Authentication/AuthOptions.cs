using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace URAL.Authentication
{
    public class AuthOptions
    {
        public const string Auth = "Auth";

        public string ISSUER { get; init; }
        public string AUDIENCE { get; init; }
        public string KEY { get; init; }
        public SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
