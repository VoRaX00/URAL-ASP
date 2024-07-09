namespace URAL.Application.RequestModels.NotifyCargo;

public record NotifyCargoToGet
{
    public ulong Id { get; init; }
    public char FirstUserStatus { get; init; }
    public char SecondUserStatus { get; init; }
    public string? FirstUserComment { get; init; }
    public string? SecondUserComment { get; init; }
    public ulong CargoId { get; init; }
    public ulong? FirstUserId { get; init; }
    public ulong? SecondUserId { get; init; }
}
