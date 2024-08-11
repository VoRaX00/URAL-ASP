namespace URAL.Application.RequestModels.NotifyCargo;

public record NotifyCargoToGet
{
    public long Id { get; init; }
    public char FirstUserStatus { get; init; }
    public char SecondUserStatus { get; init; }
    public string? FirstUserComment { get; init; }
    public string? SecondUserComment { get; init; }
    public ulong CargoId { get; init; }
    public string? FirstUserId { get; init; }
    public string? SecondUserId { get; init; }
}
