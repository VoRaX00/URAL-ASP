namespace URAL.Application.Filter;

public abstract class Filter
{
    public string? name { get; set; }
    public double? length { get; set; } 
    public double? height { get; set; } 
    public double? volume { get; set; }
    public double? width { get; set; } 
}