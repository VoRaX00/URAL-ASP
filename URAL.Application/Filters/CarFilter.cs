using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using URAL.Domain.Entities;

namespace URAL.Application.Filters;

public class CarFilter : LogisticFilter<Car>
{
    public double? Capacity { get; set; }
    public string? WhereFrom { get; set; } 
    public string? WhereTo { get; set; }
    public DateOnly? ReadyFrom { get; set; }
    public DateOnly? ReadyTo { get; set; }
    public List<string>? BodyTypes { get; set; } = new();
    public List<string>? LoadingTypes { get; set; } = new();
    private readonly static PropertyInfo[] properties = typeof(CarFilter).GetProperties();

    public override Expression<Func<Car, bool>> GetFilteringExpression()
    {
        //Expression<Func<Car, bool>> a = obj =>
        //(BodyTypes.Count == 0 || obj.BodyTypes.All(x => BodyTypes.Contains(x.Name))) &&
        //(LoadingTypes.Count == 0 || obj.LoadingTypes.All(x => LoadingTypes.Contains(x.Name)));

        return ApplyAllFiltering(properties);
    }

    protected override Expression? ApplyContainsFiltering(PropertyInfo[] properties)
    {
        //Expression body = null;

        //foreach (var property in properties.Where(x => x.PropertyType.GetInterfaces().Contains(typeof(IEnumerable<>))))
        //{
        //    var member = Expression.Property(param, property.Name);
        //    var constant = Expression.Convert(Expression.Constant(property.GetValue(this), property.PropertyType), typeof(IEnumerable<>));

        //    var zeroCountCheck = Expression.Equal(Expression.Property(constant, "Count"), Expression.Constant(0));
        //    Expression.
        //    var equalMemberToProperty = Expression.Call(member, "All", Expression.Lambda<Func<>>);

        //    var expression = Expression.OrElse(zeroCountCheck, equalMemberToProperty);

        //    body = body == null ? expression : Expression.AndAlso(body, expression);
        //}

        return null;
    }
}