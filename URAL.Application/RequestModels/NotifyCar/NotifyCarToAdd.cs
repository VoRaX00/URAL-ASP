using URAL.Domain.Enums;

namespace URAL.Application.RequestModels.NotifyCar;

public record NotifyCarToAdd
{
    public string? FirstUserComment { get; init; }
    public string? SecondUserComment { get; init; }
    public ulong CarId { get; init; }
    public string? FirstUserId { get; init; }
    public string? SecondUserId { get; init; }
}
