namespace URAL.FunctionalTests.Helpers.DataGenerators;

public interface IDataGenerator<T>
{
    List<T> Generate();
}
