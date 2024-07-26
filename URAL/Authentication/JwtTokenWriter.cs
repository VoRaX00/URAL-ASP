using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using URAL.Application.RequestModels.User;
using Microsoft.IdentityModel.Tokens;

namespace URAL.Authentication;

public class JwtTokenWriter(AuthOptions authOptions) : IJwtTokenWriter
{
    private readonly JwtSecurityTokenHandler handler = new();

    public string WriteToken(UserToGet userToGet)
    {
        var claims = GetClaims(userToGet);

        var jwt = new JwtSecurityToken(
            issuer: authOptions.ISSUER,
            audience: authOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
            signingCredentials: new SigningCredentials(authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        return handler.WriteToken(jwt);
    }

    private List<Claim> GetClaims(UserToGet userToGet)
    {
        return new List<Claim>
        {
            new(nameof(userToGet.Id), userToGet.Id),
            new(nameof(userToGet.Image), userToGet.Image),
            new(nameof(userToGet.Email), userToGet.Email),
            new(nameof(userToGet.UserName), userToGet.UserName)
        };
    }
}
