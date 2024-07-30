using Microsoft.AspNetCore.Identity;

namespace URAL.Domain.Exceptions;

public class NotValidChangePasswordException : Exception
{
    public string Email { get; }

    public IEnumerable<IdentityError> Errors { get; }

    public NotValidChangePasswordException(string email, IEnumerable<IdentityError> errors)
    {
        Email = email;
        Errors = errors;
    }
}
