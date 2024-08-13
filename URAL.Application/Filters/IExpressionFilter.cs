using System.Linq.Expressions;

namespace URAL.Application.Filters;

public interface IExpressionFilter<T>
{
    Expression<Func<T, bool>> GetFilteringExpression();
}
