namespace URAL.Application.RequestModels.NotifyCar;

public record NotifyCarToUpdate
{
    public ulong Id { get; set; }
    public char FirstUserStatus { get; init; }
    public char SecondUserStatus { get; init; }
    public string? FirstUserComment { get; init; }
    public string? SecondUserComment { get; init; }
}
