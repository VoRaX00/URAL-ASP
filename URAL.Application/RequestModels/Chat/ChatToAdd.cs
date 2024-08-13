namespace URAL.Application.RequestModels.Chat;

public record ChatToAdd
{
    public string Name { get; set; }
    public long FirstUserId { get; set; }
}