namespace URAL.Application.RequestModels.Chat;

public record ChatToUpdate
{
    public long Id { get; init; }
    public string Name { get; init; }
    public List<MessageDto> Messages { get; init; }
}