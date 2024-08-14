using URAL.Application.RequestModels.Message;

namespace URAL.Application.RequestModels.Connection;

public record SentMessage()
{
    public string UserName { get; init; }
    public MessageToAdd Message { get; init; }
}