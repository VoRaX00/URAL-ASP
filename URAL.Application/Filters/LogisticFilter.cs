using URAL.Domain.Common;

namespace URAL.Application.Filters;

public abstract class LogisticFilter<T> : IFilter<T> where T : LogisticEntity
{
    public string? name { get; set; }
    public double? length { get; set; } 
    public double? height { get; set; } 
    public double? volume { get; set; }
    public double? width { get; set; }

    public virtual bool Apply(T obj) 
    {
        return (name?.Equals(obj.Name) ?? true) &&
            (length?.Equals(obj.Length) ?? true) &&
            (height?.Equals(obj.Height) ?? true) &&
            (volume?.Equals(obj.Volume) ?? true) &&
            (width?.Equals(obj.Width) ?? true);
    }
}