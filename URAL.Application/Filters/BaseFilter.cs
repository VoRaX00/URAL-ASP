using System.Linq.Expressions;
using System.Reflection;

namespace URAL.Application.Filters;

public abstract class BaseFilter<T, FilterParameter> : IExpressionFilter<T, FilterParameter>
{
    protected static readonly ParameterExpression param = Expression.Parameter(typeof(T), "p");
    protected static readonly PropertyInfo[] properties = typeof(FilterParameter).GetProperties();

    public virtual Expression<Func<T, bool>> GetFilteringExpression(FilterParameter filterParameter)
    {
        var listClassName = typeof(List<>).Name;

        var defaultFiltering = ApplyDefaultFiltering(properties.Where(x => x.PropertyType.Name != listClassName).ToArray(), filterParameter);
        var containsFiltering = ApplyContainsFiltering(properties.Where(x => x.PropertyType.Name == listClassName).ToArray(), filterParameter);

        if (containsFiltering == null)
            return Expression.Lambda<Func<T, bool>>(defaultFiltering, param);

        return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(defaultFiltering, containsFiltering), param);
    }

    protected Expression ApplyDefaultFiltering(PropertyInfo[] properties, FilterParameter filterParameter)
    {
        Expression? body = null;

        foreach (var property in properties)
        {
            var member = Expression.Convert(Expression.Property(param, property.Name), property.PropertyType);
            var constant = Expression.Constant(property.GetValue(filterParameter), property.PropertyType);

            var nullCheck = Expression.Equal(constant, Expression.Constant(null, property.PropertyType));
            var equalMemberToProperty = Expression.Equal(member, constant);

            var expression = Expression.OrElse(nullCheck, equalMemberToProperty);

            body = body == null ? expression : Expression.AndAlso(body, expression);
        }

        return body;
    }

    protected virtual Expression? ApplyContainsFiltering(PropertyInfo[] properties, FilterParameter filterParameter)
    {
        return null;
    }
}
