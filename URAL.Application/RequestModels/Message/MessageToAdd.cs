namespace URAL.Application.RequestModels.Message;

public record MessageToAdd
{
    public string Content { get; set; }
    public long ChatId { get; set; }
}