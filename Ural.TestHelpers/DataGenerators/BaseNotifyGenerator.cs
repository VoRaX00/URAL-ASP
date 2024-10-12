using Bogus;
using URAL.Domain.Common;
using URAL.Domain.Enums;

namespace Ural.TestHelpers.DataGenerators;

public abstract class BaseNotifyGenerator<TNotify> : IDataGenerator<TNotify> where TNotify : NotifyEntity 
{
    private readonly List<Guid> userGuid;
    protected readonly Faker<TNotify> notifyFaker;
    protected readonly int count;

    public BaseNotifyGenerator(int count, List<Guid> userGuids)
    {
        this.count = count;
        this.userGuid = userGuids;
        
        var userStatus = new[] { UserStatus.Yes, UserStatus.No, UserStatus.Unknown };

        notifyFaker = new Faker<TNotify>()
            .Rules((f, n) =>
            {
                n.FirstUserStatus = f.PickRandom(userStatus);
                n.SecondUserStatus = f.PickRandom(userStatus);
                n.FirstUserComment = string.Join(' ', f.Random.WordsArray(0, 20));
                n.SecondUserComment = string.Join(' ', f.Random.WordsArray(0, 20));

                var firstUserGuid = f.PickRandom(userGuids);
            });
    }

    public abstract List<TNotify> Generate();
}
