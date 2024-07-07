using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URAL.Domain.Enums;

namespace URAL.Domain.Common
{
    public class NotifyEntity : BaseEntity
    {
        public char FirstUserStatus { get; set; }
        public char SecondUserStatus { get; set; }
        public string? FirstUserComment { get; set; }
        public string? SecondUserComment { get; set; }
        public ulong? FirstUserId { get; set; }
        public ulong? SecondUserId { get; set; }
    }
}
