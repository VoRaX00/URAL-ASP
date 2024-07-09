using URAL.Domain.Enums;

namespace URAL.Application.RequestModels.NotifyCargo;

public record NotifyCargoToAdd
{
    public char FirstUserStatus { get; init; } = UserStatus.Yes;
    public char SecondUserStatus { get; init; } = UserStatus.Unknown;
    public string? FirstUserComment { get; init; }
    public string? SecondUserComment { get; init; }
    public ulong CargoId { get; init; }
    public ulong? FirstUserId { get; init; }
    public ulong? SecondUserId { get; init; }
}
