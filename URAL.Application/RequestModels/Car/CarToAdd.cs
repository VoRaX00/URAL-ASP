namespace URAL.Application.RequestModels.Car;

public record CarToAdd
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
    public List<BodyTypeDto> BodyTypes { get; init; }
    public List<LoadingTypeDto> LoadingTypes { get; init; }
}