using Bogus;
using URAL.Domain.Entities;

namespace Ural.TestHelpers.DataGenerators;

public class CargoGenerator : IDataGenerator<Cargo>
{
    private Faker<Cargo> cargoFaker;
    private int count;
    private static string[] cargosNames =
    [
        "Сахар",
        "Песок",
        "Мясо",
        "Фрукты",
        "Азот",
        "Мука",
        "Молоко",
        "Овощи",
        "Металл",
        "Цемент"
    ];
    public CargoGenerator(int count, List<Guid> userGuid)
    {
        this.count = count;
        cargoFaker = new Faker<Cargo>()
            .Rules((f, c) =>
            {
                c.Name = f.PickRandom(cargosNames);
                c.Length = f.Random.Double(1, 50);
                c.Height = f.Random.Double(1, 50);
                c.Width = f.Random.Double(1, 50);
                c.Volume = f.Random.Double(10, 100);
                c.Weight = f.Random.Double(10, 100);
                c.CountPlace = f.Random.Double(1, 10);
                c.LoadingDate = f.Date.BetweenDateOnly(new DateOnly(2020, 1, 1), new DateOnly(2025, 12, 31));
                c.UnloadingDate = f.Date.SoonDateOnly(30, c.LoadingDate);
                c.Phone = ulong.Parse(f.Phone.PhoneNumber("8##########"));
                c.LoadingPlace = f.Address.FullAddress();
                c.UnloadingPlace = f.Address.FullAddress();
                c.Cash = f.Random.Bool();
                c.Cashless = f.Random.Bool();
                c.CashLessNds = f.Random.Bool();
                c.CashLessWithoutNds = f.Random.Bool();
                c.PriceCash = f.Random.Double(1000, 50000);
                c.PriceCashWithoutNds = f.Random.Double(1000, 50000);
                c.PriceCashNds = c.PriceCashWithoutNds * 10 / (10 + 100);
                c.RequestPrice = f.Random.Bool();
                c.Comment = string.Join(' ', f.Random.WordsArray(0, 20));
                c.UserId = f.PickRandom(userGuid).ToString();
            });
    }

    public List<Cargo> Generate()
    {
        return cargoFaker.Generate(count);
    }
}
