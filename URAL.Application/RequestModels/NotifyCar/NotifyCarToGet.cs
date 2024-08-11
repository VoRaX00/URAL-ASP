namespace URAL.Application.RequestModels.NotifyCar;

public record NotifyCarToGet
{
    public long Id { get; set; }
    public char FirstUserStatus { get; init; }
    public char SecondUserStatus { get; init; }
    public string? FirstUserComment { get; init; }
    public string? SecondUserComment { get; init; }
    public long CarId { get; init; }
    public string? FirstUserId { get; init; }
    public string? SecondUserId { get; init; }
}
