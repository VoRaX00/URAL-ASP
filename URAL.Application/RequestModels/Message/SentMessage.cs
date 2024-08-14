namespace URAL.Application.RequestModels.Message;

public record SentMessage()
{
    public string UserName { get; init; }
    public MessageToAdd Message { get; init; }
}