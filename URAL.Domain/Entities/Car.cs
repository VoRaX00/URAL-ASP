using URAL.Domain.Common;

namespace URAL.Domain.Entities;

public class Car : LogisticEntity
{
    public double Capacity { get; set; }
    public string WhereFrom { get; set; }
    public string WhereTo { get; set; }
    public DateOnly ReadyFrom { get; set; }
    public DateOnly ReadyTo { get; set; }
    public ulong Phone { get; set; }
    public string? Comment { get; set; }
    public string UserId { get; set; }
    public User? User { get; set; }
    public List<BodyType> BodyTypes { get; set; } = [];
    public List<LoadingType> LoadingTypes { get; set; } = [];
    public List<NotifyCar> NotifyCars { get; set; } = [];
}
