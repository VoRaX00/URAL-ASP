using System.Linq.Expressions;

namespace URAL.Application.Filters;

public interface IExpressionFilter<T, FilterParameter>
{
    Expression<Func<T, bool>> GetFilteringExpression(FilterParameter filterParameter);
}
