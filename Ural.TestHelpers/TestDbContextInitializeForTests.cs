using Bogus;
using Ural.TestHelpers.DataGenerators;
using URAL.Domain.Entities;
using URAL.Infrastructure.Context;

namespace URAL.FunctionalTests;

public static class TestDbContextInitializeForTests
{
    private readonly static int seed = 44323232;

    private readonly static int userCount = 5;
    private readonly static int logisticObjectCount = 10;
    private readonly static int notifyObjectCount = 20;

    private readonly static List<Guid> guids;

    private readonly static IDataGenerator<BodyType> bodyTypesGenerator;
    private readonly static IDataGenerator<LoadingType> loadingTypesGenerator;
    private readonly static IDataGenerator<Cargo> cargoGenerator;
    private readonly static IDataGenerator<Car> carsGenerator;
    private readonly static IDataGenerator<NotifyCargo> notifyCargoGenerator;
    private readonly static IDataGenerator<NotifyCar> notifyCarsGenerator;
    private readonly static IDataGenerator<User> usersGenerator;

    static TestDbContextInitializeForTests()
    {
        Randomizer.Seed = new Random(seed);
        guids = GetGuids(userCount);

        bodyTypesGenerator = new BodyTypesGenerator();
        loadingTypesGenerator = new LoadingTypesGenerator();
        cargoGenerator = new CargoGenerator(logisticObjectCount, guids);
        carsGenerator = new CarsGenerator(logisticObjectCount, guids, seed);
        notifyCargoGenerator = new NotifyCargoGenerator(logisticObjectCount, notifyObjectCount, guids);
        notifyCarsGenerator = new NotifyCarsGenerator(logisticObjectCount, notifyObjectCount, guids);
    }

    private static List<Guid> GetGuids(int count)
    {
        var result = new List<Guid>();
        var faker = new Faker();

        for (int i = 0; i < count; i++)
            result.Add(faker.Random.Guid());
        
        return result;
    }

    public static void InitializeDbForTests(UralDbContext db)
    {
        Randomizer.Seed = new Random(seed);

        db.BodyTypes.AddRange(GetSeedingBodyTypes());
        db.LoadingTypes.AddRange(GetSeedingLoadingTypes());
        db.Cargo.AddRange(GetSeedingCargo());
        db.Cars.AddRange(GetSeedingCars());
        db.NotifyCargo.AddRange(GetSeedingNotifyCargo());
        db.NotifyCars.AddRange(GetSeedingNotifyCars());
        db.Users.AddRange(GetSeedingUsers());

        db.SaveChanges();
    }

    public static void ReinitializeDbForTests(UralDbContext db)
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

    private static List<BodyType> GetSeedingBodyTypes()
    {
        return bodyTypesGenerator.Generate();
    }

    private static List<LoadingType> GetSeedingLoadingTypes()
    {
        return loadingTypesGenerator.Generate();
    }

    private static List<Cargo> GetSeedingCargo()
    {
        return cargoGenerator.Generate();
    }

    private static List<Car> GetSeedingCars()
    {
        return carsGenerator.Generate();
    }

    private static List<NotifyCargo> GetSeedingNotifyCargo()
    {
        return notifyCargoGenerator.Generate();
    }

    private static List<NotifyCar> GetSeedingNotifyCars()
    {
        return notifyCarsGenerator.Generate();
    }

    private static List<User> GetSeedingUsers()
    {
        return usersGenerator.Generate();
    }
}
