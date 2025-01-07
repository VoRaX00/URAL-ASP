using Bogus;
using URAL.FunctionalTests.Helpers.DataGenerators;
using URAL.Infrastructure.Context;

namespace URAL.FunctionalTests.Helpers;

public static class DatabaseSeederForTests
{
    private static readonly int seed = 44323232;

    private static readonly int userCount = 4;
    private static readonly int logisticObjectCount = 8;
    private static readonly int notifyObjectCount = 12;

    private static readonly List<Guid> guids;

    static DatabaseSeederForTests()
    {
        Randomizer.Seed = new Random(seed);
        guids = GetGuids(userCount);
    }

    private static List<Guid> GetGuids(int count)
    {
        var result = new List<Guid>();
        var faker = new Faker();

        for (var i = 0; i < count; i++)
            result.Add(faker.Random.Guid());

        return result;
    }

    public static void SeedDatabaseWithTestData(this UralDbContext db)
    {
        Randomizer.Seed = new Random(seed);

        var bodyTypes = new BodyTypesGenerator().Generate();
        var loadingTypes = new LoadingTypesGenerator().Generate();
        var cars = new CarsGenerator(bodyTypes, loadingTypes, logisticObjectCount, guids).Generate();
        var cargos = new CargoGenerator(logisticObjectCount, guids).Generate();
        var notifyCargos = new NotifyCargoGenerator(cargos, notifyObjectCount, guids).Generate();
        var notifyCars = new NotifyCarsGenerator(cars, notifyObjectCount, guids).Generate();
        var users = new UserGenerator(guids).Generate();

        db.Users.AddRange(users);
        db.BodyTypes.AddRange(bodyTypes);
        db.LoadingTypes.AddRange(loadingTypes);
        db.Cargo.AddRange(cargos);
        db.Cars.AddRange(cars);
        db.NotifyCargo.AddRange(notifyCargos);
        db.NotifyCars.AddRange(notifyCars);

        db.SaveChanges();
    }
}
