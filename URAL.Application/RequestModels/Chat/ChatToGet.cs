using URAL.Application.RequestModels.Message;

namespace URAL.Application.RequestModels.Chat;

public record ChatToGet
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<MessageToGet> Messages { get; init; }
    public string FirstUserId { get; init; }
    public string SecondUserId { get; init; }
}