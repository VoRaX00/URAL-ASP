namespace URAL.Application.RequestModels.Chat;

public record ChatToAdd
{
    public string Name { get; init; }
    public long FirstUserId { get; init; }
}