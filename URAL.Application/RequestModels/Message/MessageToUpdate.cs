namespace URAL.Application.RequestModels.Message;

public record MessageToUpdate
{
    public long Id { get; init; }
    public string Content { get; init; }
    
}