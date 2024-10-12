using Bogus;
using URAL.Domain.Entities;

namespace Ural.TestHelpers.DataGenerators;

public class UserGenerator : IDataGenerator<User>
{
    private readonly Faker<User> userFaker;
    private readonly List<Guid> guids;

    public UserGenerator(List<Guid> userGuids)
    {
        guids = userGuids;

        userFaker = new Faker<User>()
            .Rules((f, u) =>
            {
                u.UserName = f.Person.FullName;
                u.AboutMe = string.Join(' ', f.Random.WordsArray(0, 20));
                u.IsStaff = f.Random.Bool();
                u.DateJoined = f.Date.Between(new DateTime(2020, 1, 1), new DateTime(2024, 12, 31));
                u.Email = f.Internet.Email(u.UserName);
                u.PasswordHash = f.Internet.Password();
                u.PhoneNumber = f.Person.Phone;
            });
    }

    public List<User> Generate(Dictionary<string, List<object>>? relationsShipObjects)
    {
        var guidsQueue = new Queue<Guid>(guids);
        var result = userFaker.Generate(guids.Count);

        for (var i = 0; i < result.Count; i++)
            result[i].Id = guidsQueue.Dequeue().ToString();

        return result;
    }
}
