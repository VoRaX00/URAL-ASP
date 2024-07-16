namespace URAL.Application.RequestModels.NotifyCar;

public record NotifyCarToGet
{
    public ulong Id { get; set; }
    public char FirstUserStatus { get; init; }
    public char SecondUserStatus { get; init; }
    public string? FirstUserComment { get; init; }
    public string? SecondUserComment { get; init; }
    public ulong CarId { get; init; }
    public ulong? FirstUserId { get; init; }
    public ulong? SecondUserId { get; init; }
}
