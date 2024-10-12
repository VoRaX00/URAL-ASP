namespace Ural.TestHelpers.DataGenerators;

public interface IDataGenerator<T>
{
    List<T> Generate();
}
