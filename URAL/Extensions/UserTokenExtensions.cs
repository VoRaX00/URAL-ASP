using System.Security.Claims;
using System.Security.Principal;

namespace URAL.Extensions;

public static class UserTokenExtensions
{
    public static string GetClaimByType(this ClaimsPrincipal principal, string type)
    {
        return principal.Claims.First(x => x.Type == type).Value;
    }

    public static string GetUserIdFromClaim(this ClaimsPrincipal principal)
    {
        return principal.GetClaimByType("Id");
    }
}
