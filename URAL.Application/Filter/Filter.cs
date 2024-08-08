namespace URAL.Application.Filter;

public abstract class Filter
{
    public string? Name { get; set; }
    public double? Length { get; set; } 
    public double? Height { get; set; } 
    public double? Volume { get; set; }
    public double? Width { get; set; } 
}