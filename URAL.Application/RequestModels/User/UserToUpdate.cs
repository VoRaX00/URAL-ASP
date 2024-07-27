namespace URAL.Application.RequestModels.User;

public record UserToUpdate
{
    public string Id { get; init; }
    public string Password { get; init; }
    public string UserName { get; init; }
    public string Email { get; init; }
    public ulong? PhoneNumber { get; init; }
    public string AboutMe { get; init; }
    public string Image { get; init; }
}
