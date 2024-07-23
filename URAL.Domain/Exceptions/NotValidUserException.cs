using Microsoft.AspNetCore.Identity;
using URAL.Domain.Entities;

namespace URAL.Domain.Exceptions;

public class NotValidUserException(User user, IEnumerable<IdentityError> errors) : Exception
{
    public User User { get; } = user;
    public IEnumerable<IdentityError> Errors { get; } = errors;
}
