using URAL.Application.RequestModels.User;

namespace URAL.Authentication;

public interface IJwtTokenWriter
{
    public string WriteToken(UserToGet userToGet);
}
