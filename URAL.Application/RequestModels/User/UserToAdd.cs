namespace URAL.Application.RequestModels.User;

public record UserToAdd
{
    public string Password { get; init; }
    public string UserName { get; init; }
    public string Email { get; init; }
    public ulong? PhoneNumber { get; init; }
    // public string Image { get; init; }
}
