using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using URAL.Application.RequestModels.User;
using Microsoft.IdentityModel.Tokens;
using URAL.Domain.Enums;

namespace URAL.Authentication;

public class JwtTokenWriter(AuthOptions authOptions) : IJwtTokenWriter
{
    private readonly JwtSecurityTokenHandler handler = new();

    public string WriteToken(UserFullInfo userFullInfo)
    {
        var claims = GetClaims(userFullInfo);

        var jwt = new JwtSecurityToken(
            issuer: authOptions.ISSUER,
            audience: authOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
            signingCredentials: new SigningCredentials(authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        return handler.WriteToken(jwt);
    }

    private List<Claim> GetClaims(UserFullInfo userFullInfo)
    {
        return new List<Claim>
        {
            new(nameof(userFullInfo.Id), userFullInfo.Id),
            new(nameof(userFullInfo.Image), userFullInfo.Image),
            new(nameof(userFullInfo.Email), userFullInfo.Email),
            new(nameof(userFullInfo.UserName), userFullInfo.UserName),
            new(IdentityData.StaffUserClaimName, userFullInfo.IsStaff.ToString()),
            new(IdentityData.AdminUserClaimName, userFullInfo.IsSuperuser.ToString())
        };
    }
}
