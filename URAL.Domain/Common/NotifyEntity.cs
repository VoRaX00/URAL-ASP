using URAL.Domain.Entities;
using URAL.Domain.Enums;

namespace URAL.Domain.Common
{
    public abstract class NotifyEntity : BaseEntity
    {
        public char FirstUserStatus { get; set; } = UserStatus.Yes;
        public char SecondUserStatus { get; set; } = UserStatus.Unknown;
        public string? FirstUserComment { get; set; }
        public string? SecondUserComment { get; set; }
        public string? FirstUserId { get; set; }
        public User? FirstUser { get; set; }
        public string? SecondUserId { get; set; }
        public User? SecondUser { get; set; }
    }
}
