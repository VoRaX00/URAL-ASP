using URAL.Application.RequestModels.Message;

namespace URAL.Application.RequestModels.Chat;

public record ChatToImage()
{
    public long Id { get; init; }
    public string Name { get; init; }
    public MessageToGet? LastMessage { get; set; }
    public string FirstUserId { get; init; }
    public string SecondUserId { get; init; }
    public long NotifyId { get; init; }
}