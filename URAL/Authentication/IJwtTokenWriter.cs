using URAL.Application.RequestModels.User;
using URAL.Domain.Enums;

namespace URAL.Authentication;

public interface IJwtTokenWriter
{
    public string WriteToken(UserFullInfo userFullInfo);
}
