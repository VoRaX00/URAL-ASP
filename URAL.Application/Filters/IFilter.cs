namespace URAL.Application.Filters;

public interface IFilter<T>
{
    bool Apply(T obj);
}
