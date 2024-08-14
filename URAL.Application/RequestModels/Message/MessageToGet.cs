namespace URAL.Application.RequestModels.Message;

public record MessageToGet
{
    public long Id { get; init; }
    public string UserId { get; init; }
    public long ChatId { get; init; }
    public string Content { get; init; }
    public DateTime SentAt { get; init; }
}