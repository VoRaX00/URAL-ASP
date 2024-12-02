namespace URAL.Domain.Entities;

public class RefreshToken
{
    public string IpAddress { get; set; }
    public string TokenHash { get; set; }
    public DateTime Expires { get; set; }
    public DateTime Created { get; set; }
    public DateTime Revoked { get; set; }
}