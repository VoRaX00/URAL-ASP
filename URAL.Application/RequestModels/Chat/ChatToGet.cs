using URAL.Application.RequestModels.Message;

namespace URAL.Application.RequestModels.Chat;

public record ChatToGet
{
    public long Id { get; init; }
    public string Name { get; init; }
    public List<MessageToGet> Messages { get; init; }
    public string FirstUserId { get; init; }
    public string SecondUserId { get; init; }
}