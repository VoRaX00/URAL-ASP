namespace URAL.Application.RequestModels.Message;

public record MessageToAdd
{
    public string UserId { get; init; }
    public long ChatId { get; init; }
    public string Content { get; init; }
} 