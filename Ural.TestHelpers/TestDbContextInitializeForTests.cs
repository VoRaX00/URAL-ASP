using Bogus;
using Ural.TestHelpers.DataGenerators;
using URAL.Domain.Entities;
using URAL.Infrastructure.Context;

namespace URAL.FunctionalTests;

public static class TestDbContextInitializeForTests
{
    private readonly static int seed = 44323232;

    private readonly static int userCount = 4;
    private readonly static int logisticObjectCount = 8;
    private readonly static int notifyObjectCount = 12;

    private readonly static List<Guid> guids;

    static TestDbContextInitializeForTests()
    {
        Randomizer.Seed = new Random(seed);
        guids = GetGuids(userCount);
    }

    private static List<Guid> GetGuids(int count)
    {
        var result = new List<Guid>();
        var faker = new Faker();

        for (int i = 0; i < count; i++)
            result.Add(faker.Random.Guid());
        
        return result;
    }

    public static void InitializeDbForTests(this UralDbContext db)
    {
        Randomizer.Seed = new Random(seed);

        var bodyTypesGenerator = new BodyTypesGenerator();
        var loadingTypesGenerator = new LoadingTypesGenerator();
        var bodyTypes = bodyTypesGenerator.Generate();
        var loadingTypes = loadingTypesGenerator.Generate();

        var cargoGenerator = new CargoGenerator(logisticObjectCount, guids);
        var carsGenerator = new CarsGenerator(bodyTypes, loadingTypes, logisticObjectCount, guids);
        var cars = carsGenerator.Generate();
        var cargos = cargoGenerator.Generate();

        var notifyCargoGenerator = new NotifyCargoGenerator(cargos, notifyObjectCount, guids);
        var notifyCarsGenerator = new NotifyCarsGenerator(cars, notifyObjectCount, guids);
        var usersGenerator = new UserGenerator(guids);

        db.Users.AddRange(usersGenerator.Generate());
        db.BodyTypes.AddRange(bodyTypes);
        db.LoadingTypes.AddRange(loadingTypes);
        db.Cargo.AddRange(cargos);
        db.Cars.AddRange(cars);
        db.NotifyCargo.AddRange(notifyCargoGenerator.Generate());
        db.NotifyCars.AddRange(notifyCarsGenerator.Generate());
        

        db.SaveChanges();
    }

    public static void ReinitializeDbForTests(this UralDbContext db)
    {
        db.BodyTypes.RemoveRange(db.BodyTypes);
        db.LoadingTypes.RemoveRange(db.LoadingTypes);
        db.Cargo.RemoveRange(db.Cargo);
        db.Cars.RemoveRange(db.Cars);
        db.NotifyCargo.RemoveRange(db.NotifyCargo);
        db.NotifyCars.RemoveRange(db.NotifyCars);
        db.Users.RemoveRange(db.Users);

        InitializeDbForTests(db);
    }
}
