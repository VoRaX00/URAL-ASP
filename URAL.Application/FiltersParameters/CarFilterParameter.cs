namespace URAL.Application.FiltersParameters;

public record CarFilterParameter : LogisticParameter
{
    public double? Capacity { get; init; }
    public string? WhereFrom { get; init; }
    public string? WhereTo { get; init; }
    public DateOnly? ReadyFrom { get; init; }
    public DateOnly? ReadyTo { get; init; }
    public List<string>? BodyTypes { get; init; } = new();
    public List<string>? LoadingTypes { get; init; } = new();
}
