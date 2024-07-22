namespace URAL.Application.RequestModels.User;

public record UserToGet
{
    public string Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public ulong? Phone { get; init; }
    public string AboutMe { get; init; }
    public string Image { get; init; }
    public bool IsActive { get; init; }
    public bool IsStaff { get; init; }
    public bool IsSuperuser { get; init; }
    public DateTime DateJoined { get; init; }
    public DateTime? LastLogin { get; init; }
}
