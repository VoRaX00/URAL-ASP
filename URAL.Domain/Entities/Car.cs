using URAL.Domain.Common;

namespace URAL.Domain.Entities;

public class Car : BaseEntity
{
    public string Name { get; set; }
    public double Capacity { get; set; }
    public double Volume { get; set; }
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public string WhereFrom { get; set; }
    public string WhereTo { get; set; }
    public DateOnly ReadyFrom { get; set; }
    public DateOnly ReadyTo { get; set; }
    public ulong Phone { get; set; }
    public string? Comment { get; set; }
    public ulong UserId { get; set; }
    public User? User { get; set; }
    public List<BodyType> BodyTypes { get; set; } = [];
    public List<LoadingType> LoadingTypes { get; set; } = [];
    public List<NotifyCar> NotifyCars { get; set; } = [];
}
