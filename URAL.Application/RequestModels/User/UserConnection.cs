namespace URAL.Application.RequestModels.Connection;

public record UserConnection()
{
    public long ChatId { get; init; }
    public string UserId { get; init; }
    public string UserName { get; init; }
}