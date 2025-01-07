using Bogus;
using URAL.Domain.Common;
using URAL.Domain.Enums;

namespace URAL.FunctionalTests.Helpers.DataGenerators;

public abstract class BaseNotifyGenerator<TNotify> : IDataGenerator<TNotify> where TNotify : NotifyEntity
{
    protected readonly Faker<TNotify> notifyFaker;
    protected readonly int count;

    protected BaseNotifyGenerator(int count)
    {
        this.count = count;

        var userStatus = new[] { UserStatus.Yes, UserStatus.No, UserStatus.Unknown };

        notifyFaker = new Faker<TNotify>()
            .Rules((f, n) =>
            {
                n.FirstUserStatus = f.PickRandom(userStatus);
                n.SecondUserStatus = f.PickRandom(userStatus);
                n.FirstUserComment = string.Join(' ', f.Random.WordsArray(0, 20));
                n.SecondUserComment = string.Join(' ', f.Random.WordsArray(0, 20));
            });
    }

    public abstract List<TNotify> Generate();
}
