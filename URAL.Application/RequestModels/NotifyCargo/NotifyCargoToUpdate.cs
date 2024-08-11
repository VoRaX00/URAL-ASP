namespace URAL.Application.RequestModels.NotifyCargo;

public record NotifyCargoToUpdate
{
    public long Id { get; init; }
    public char FirstUserStatus { get; init; }
    public char SecondUserStatus { get; init; }
    public string? FirstUserComment { get; init; }
    public string? SecondUserComment { get; init; }
}
