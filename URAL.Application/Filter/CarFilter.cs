using URAL.Domain.Entities;

namespace URAL.Application.Filter;

public class CarFilter : Filter
{
    public double? capacity { get; set; }
    public string? whereFrom { get; set; } 
    public string? whereTo { get; set; }
    public DateOnly? readyFrom { get; set; }
    public DateOnly? readyTo { get; set; } 
    public List<string>? bodyTypes { get; set; }
    public List<string>? loadingTypes { get; set; }
}