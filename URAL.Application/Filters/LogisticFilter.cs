using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;
using System.Reflection;
using URAL.Domain.Common;

namespace URAL.Application.Filters;

public abstract class LogisticFilter<T> : BaseFilter<T> where T : LogisticEntity
{
    public string? Name { get; set; }
    public double? Length { get; set; }
    public double? Height { get; set; }
    public double? Volume { get; set; }
    public double? Width { get; set; }

    private readonly static PropertyInfo[] properties =  typeof(LogisticFilter<T>).GetProperties();

    public override Expression<Func<T, bool>> GetFilteringExpression()
    {
        var properties = LogisticFilter<T>.properties;

        return ApplyAllFiltering(properties);
    }


}