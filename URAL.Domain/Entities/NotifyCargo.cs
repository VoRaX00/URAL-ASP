using URAL.Domain.Common;

namespace URAL.Domain.Entities;

public class NotifyCargo : NotifyEntity
{
    public long CargoId { get; set; }
    public Cargo? Cargo { get; set; }
}
