using URAL.Domain.Entities;

namespace URAL.Application.Filters;

public class CarFilter : LogisticFilter<Car>
{
    public double? capacity { get; set; }
    public string? whereFrom { get; set; } 
    public string? whereTo { get; set; }
    public DateOnly? readyFrom { get; set; }
    public DateOnly? readyTo { get; set; }
    public List<string>? bodyTypes { get; set; } = new();
    public List<string>? loadingTypes { get; set; } = new();

    public override bool Apply(Car obj)
    {
        return base.Apply(obj) &&
            (capacity?.Equals(obj.Capacity) ?? true) &&
            (whereFrom?.Equals(obj.WhereFrom) ?? true) &&
            (whereTo?.Equals(obj.WhereTo) ?? true) &&
            (readyFrom?.Equals(obj.ReadyFrom) ?? true) &&
            (readyTo?.Equals(obj.ReadyTo) ?? true) &&
            (bodyTypes.Count == 0 || obj.BodyTypes.All(x => bodyTypes.Contains(x.Name))) &&
            (loadingTypes.Count == 0 || obj.LoadingTypes.All(x => loadingTypes.Contains(x.Name)));
    }
}