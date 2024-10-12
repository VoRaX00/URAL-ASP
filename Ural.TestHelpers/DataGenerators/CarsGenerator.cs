﻿using Bogus;
using URAL.Domain.Entities;

namespace Ural.TestHelpers.DataGenerators;

public class CarsGenerator : IDataGenerator<Car>
{
    private readonly int count;
    private readonly int seed;
    private readonly Faker<Car> carFaker;

    public CarsGenerator(int count, List<Guid> userGuids, int seed)
    {
        this.count = count;

        carFaker = new Faker<Car>()
            .Rules((f, c) =>
            {
                c.Name = f.Vehicle.Manufacturer() + f.Vehicle.Model();
                c.Length = f.Random.Double(1, 50);
                c.Height = f.Random.Double(1, 50);
                c.Width = f.Random.Double(1, 50);
                c.Volume = f.Random.Double(10, 100);
                c.Capacity = f.Random.Double(400, 1500);
                c.WhereFrom = f.Address.FullAddress();
                c.WhereTo = f.Address.FullAddress();
                c.ReadyFrom = f.Date.BetweenDateOnly(new DateOnly(2020, 1, 1), new DateOnly(2025, 12, 31));
                c.ReadyTo = f.Date.SoonDateOnly(20, c.ReadyFrom);
                c.Phone = ulong.Parse(f.Phone.PhoneNumber());
                c.Comment = string.Join(' ', f.Random.WordsArray(0, 20));
                c.UserId = f.PickRandom(userGuids).ToString();
            });
    }

    public List<Car> Generate(Dictionary<string, List<object>>? relationsShipObjects)
    {
        var result = carFaker.Generate(count);
        var random = new Random(seed);

        if (relationsShipObjects.ContainsKey("bodyTypes"))
        {
            var objects = relationsShipObjects["bodyTypes"].Cast<BodyType>().ToArray();

            foreach (var car in result)
                car.BodyTypes = random.GetItems(objects, random.Next(1, objects.Length)).ToList();
        }

        if (relationsShipObjects.ContainsKey("loadingTypes"))
        {
            var objects = relationsShipObjects["loadingTypes"].Cast<LoadingType>().ToArray();

            foreach (var car in result)
                car.LoadingTypes = random.GetItems(objects, random.Next(1, objects.Length)).ToList();
        }

        return result;
    }
}