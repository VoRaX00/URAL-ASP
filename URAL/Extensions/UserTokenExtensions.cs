using System.Security.Claims;
using System.Security.Principal;

namespace URAL.Extensions;

public static class UserTokenExtensions
{
    public static string GetClaimByType(this ClaimsPrincipal principal, string type)
    {
        return principal.Claims.First(x => x.Type == type).Value;
    }

    public static ulong GetUserIdFromClaim(this ClaimsPrincipal principal)
    {
        return ulong.Parse(principal.GetClaimByType("Id"));
    }
}
