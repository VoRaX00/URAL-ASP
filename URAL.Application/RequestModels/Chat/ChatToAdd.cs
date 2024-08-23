namespace URAL.Application.RequestModels.Chat;

public record ChatToAdd
{
    public string Name { get; init; }
    public long? NotifyCargoId { get; init; }
    public long? NotifyCarId { get; init; }
    public string FirstUserId { get; init; }
}