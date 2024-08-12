using System.Linq.Expressions;
using System.Reflection;

namespace URAL.Application.Filters;

public abstract class BaseFilter<T> : IExpressionFilter<T>
{
    protected readonly static ParameterExpression param = Expression.Parameter(typeof(T), "p");

    public abstract Expression<Func<T, bool>> GetFilteringExpression();


    protected Expression<Func<T, bool>> ApplyAllFiltering(PropertyInfo[] properties)
    {
        var defaultFiltering = ApplyDefaultFiltering(properties);
        var containsFiltering = ApplyContainsFiltering(properties);

        if (containsFiltering == null)
            return Expression.Lambda<Func<T, bool>>(defaultFiltering, param);

        return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(defaultFiltering, containsFiltering), param);
    }

    protected Expression ApplyDefaultFiltering(PropertyInfo[] properties)
    {
        Expression? body = null;

        foreach (var property in properties.Where(x => x.PropertyType != typeof(IEnumerable<>)))
        {
            var member = Expression.Convert(Expression.Property(param, property.Name), property.PropertyType);
            var constant = Expression.Constant(property.GetValue(this), property.PropertyType);

            var nullCheck = Expression.Equal(constant, Expression.Constant(null, property.PropertyType));
            var equalMemberToProperty = Expression.Equal(member, constant);

            var expression = Expression.OrElse(nullCheck, equalMemberToProperty);

            body = body == null ? expression : Expression.AndAlso(body, expression);
        }

        return body;
    }

    protected virtual Expression? ApplyContainsFiltering(PropertyInfo[] properties)
    {
        return null;
    }
}
