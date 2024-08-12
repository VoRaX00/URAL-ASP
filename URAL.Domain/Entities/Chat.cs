using URAL.Domain.Common;

namespace URAL.Domain.Entities;

public class Chat : BaseEntity
{
    public string Name { get; set; }
    public List<Message> Messages { get; set; } = [];
    public string FirstUserId { get; set; }
    public User FirstUser { get; set; }
    public string SecondUserId { get; set; }
    public User SecondUser { get; set; }
}