using URAL.Domain.Common;

namespace URAL.Domain.Entities;

public class RefreshToken : BaseEntity
{
    public string IpAddress { get; set; } = "";
    public string UserId { get; set; } = "";
    public string TokenHash { get; set; } = "";
    public DateTime Expires { get; set; }
    public DateTime Created { get; set; }
    public string Subject { get; set; } = "";
}