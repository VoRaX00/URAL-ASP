using URAL.Domain.Entities;

namespace URAL.Application.Filter;

public abstract class CarFilter : Filter
{
    public double? Capacity { get; set; }
    public string? WhereFrom { get; set; } 
    public string? WhereTo { get; set; }
    public DateOnly? ReadyFrom { get; set; }
    public DateOnly? ReadyTo { get; set; } 
    public List<BodyType>? BodyTypes { get; set; }
    public List<LoadingType>? LoadingTypes { get; set; }
}