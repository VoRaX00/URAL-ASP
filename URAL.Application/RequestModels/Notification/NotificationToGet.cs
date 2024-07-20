using URAL.Application.RequestModels.BodyType;
using URAL.Application.RequestModels.LoadingType;

namespace URAL.Application.RequestModels.Notification;

public class NotificationToGet
{
    public ulong Id;
    public NotifyType NotifyType { get; private set; }
    private Notify notification;
    public Notify Notification 
    { 
        get => notification; 
        private set
        {
            notification = value;
            NotifyType = GetNotifyType(notification);
        } 
    }

    public NotificationToGet(ulong id, Notify notify)
    {
        Id = id;
        Notification = notify;
    }

    private NotifyType GetNotifyType(Notify notify)
    {
        if (notify is NotifyCargoDto)
            return NotifyType.Cargo;
        return NotifyType.Car;
    }
}

public abstract record Notify
{
    public ulong Id { get; init; }
}


public record NotifyCargoDto : Notify
{
    public string Name { get; init; }
    public double Length { get; init; }
    public double Width { get; init; }
    public double Height { get; init; }
    public double Weight { get; init; }
    public double Volume { get; init; }
    public double CountPlace { get; init; }
    public DateOnly LoadingDate { get; init; }
    public DateOnly UnloadingDate { get; init; }
    public ulong Phone { get; init; }
    public string LoadingPlace { get; init; }
    public string UnloadingPlace { get; init; }
    public bool? Cash { get; init; }
    public bool? Cashless { get; init; }
    public bool? CashLessNds { get; init; }
    public bool? CashLessWithoutNds { get; init; }
    public double? PriceCash { get; init; }
    public double? PriceCashNds { get; init; }
    public double? PriceCashWithoutNds { get; init; }
    public bool? RequestPrice { get; init; }
    public string? Comment { get; init; }
    public ulong UserId { get; init; }
}

public record NotifyCarDto : Notify
{
    public string Name { get; init; }
    public double Capacity { get; init; }
    public double Volume { get; init; }
    public double Length { get; init; }
    public double Width { get; init; }
    public double Height { get; init; }
    public string WhereFrom { get; init; }
    public string WhereTo { get; init; }
    public DateOnly ReadyFrom { get; init; }
    public DateOnly ReadyTo { get; init; }
    public ulong Phone { get; init; }
    public string? Comment { get; init; }
    public ulong UserId { get; init; }
    public List<BodyTypeToGet> BodyTypes { get; init; }
    public List<LoadingTypeToGet> LoadingTypes { get; init; }
}

public enum NotifyType
{
    Car,
    Cargo
}
