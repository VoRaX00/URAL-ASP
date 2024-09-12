using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;
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

    private static readonly PropertyInfo[] properties = typeof(CarFilter).GetProperties();
    private static readonly MethodInfo selectInfo = typeof(Enumerable).GetMethods().FirstOrDefault(x => x.Name == "Select");
    private static readonly MethodInfo exceptInfo = typeof(Enumerable).GetMethods().FirstOrDefault(x => x.Name == "Except").MakeGenericMethod(typeof(string));
    private static readonly MethodInfo anyInfo = typeof(Enumerable).GetMethods().FirstOrDefault(x => x.Name == "Any").MakeGenericMethod(typeof(string));

    public override Expression<Func<Car, bool>> GetFilteringExpression()
    {
        return ApplyAllFiltering(properties);
    }

    protected override Expression? ApplyContainsFiltering(PropertyInfo[] properties)
    {
        Expression body = null;

        foreach (var property in properties)
        {
            var member = Expression.Property(param, property.Name);
            var constant = Expression.Constant(property.GetValue(this));

            var zeroCheck = Expression.Equal(Expression.Property(constant, "Count"), Expression.Constant(0));

            var paramForLambda = Expression.Parameter(member.Type.GenericTypeArguments[0], "x");
            var lambdaForSelect = Expression.Lambda(Expression.Property(paramForLambda, "Name"), paramForLambda);

            var genericSelectInfo = selectInfo.MakeGenericMethod(member.Type.GenericTypeArguments[0], typeof(string));

            var selectCallForMember = Expression.Call(genericSelectInfo, member, lambdaForSelect);
            var leftCheck = CreateExceptCheck(constant, selectCallForMember);
            var rightCheck = CreateExceptCheck(selectCallForMember, constant);
            var containsCheck = Expression.Not(Expression.OrElse(leftCheck, rightCheck));

            var expression = Expression.OrElse(zeroCheck, containsCheck);

            body = body == null ? expression : Expression.AndAlso(body, expression);
        }

        return body;
    }

    private Expression CreateExceptCheck(Expression firstValue, Expression secondValue)
    {
        return Expression.Call(anyInfo, Expression.Call(exceptInfo, firstValue, secondValue));
    }
}