using URAL.Domain.Entities;

namespace URAL.FunctionalTests.Helpers.DataGenerators;

public class LoadingTypesGenerator : IDataGenerator<LoadingType>
{
    public List<LoadingType> Generate()
    {
        return
        [
            new() { Name = "Top" },
            new() { Name = "Side" },
            new() { Name = "Rear" }
        ];
    }
}
