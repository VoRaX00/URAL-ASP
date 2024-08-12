using URAL.Domain.Common;

namespace URAL.Domain.Entities;

public class Message : BaseEntity
{
    public string Content { get; set; }
    public DateTime SentAt { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public long ChatId { get; set; }
    public Chat Chat { get; set; }
}