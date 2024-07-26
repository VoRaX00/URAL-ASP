namespace URAL.Application.RequestModels.User;

public record UserToGet
{
    public string Id { get; init; }
    public string UserName { get; init; }
    public string Email { get; init; }
    public ulong? PhoneNumber { get; init; }
    public string AboutMe { get; init; }
    public string Image { get; init; }
    public bool IsActive { get; init; }
    public bool IsStaff { get; init; }
    public bool EmailConfirmed { get; init; }
    public DateTime DateJoined { get; init; }
    public DateTime? LastLogin { get; init; }
}
