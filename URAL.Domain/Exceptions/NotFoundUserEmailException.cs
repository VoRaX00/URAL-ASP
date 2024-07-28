namespace URAL.Domain.Exceptions
{
    public class NotFoundUserEmailException(string email) : Exception
    {
        public string Email { get; } = email;
    }
}
