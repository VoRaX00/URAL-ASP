using URAL.Domain.Entities;

namespace Ural.TestHelpers.DataGenerators;

public class LoadingTypesGenerator : IDataGenerator<LoadingType>
{
    public List<LoadingType> Generate(Dictionary<string, List<object>>? relationsShipObjects)
    {
        return
        [
            new() { Name = "Top" },
            new() { Name = "Side" },
            new() { Name = "Rear" }
        ];
    }
}
