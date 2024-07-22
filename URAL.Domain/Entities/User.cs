using URAL.Domain.Common;

namespace URAL.Domain.Entities;

public class User : BaseEntity
{
    public string Password {  get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ulong? Phone { get; set; }
    public string AboutMe { get; set; }
    public string Image { get; set; }
    public bool IsActive { get; set; }
    public bool IsStaff { get; set; }
    public bool IsSuperuser { get; set; }
    public DateTime DateJoined { get; set; }
    public DateTime? LastLogin { get; set; }
    public List<Car> Cars { get; set; } = [];
    public List<Cargo> Cargo { get; set; } = [];
    
    public List<NotifyCar> FirstNotifyCars { get; set; } = [];
    public List<NotifyCar> SecondNotifyCars { get; set; } = [];
    
    public List<NotifyCargo> FirstNotifyCargo { get; set; } = [];
    public List<NotifyCargo> SecondNotifyCargo { get; set; } = [];
}
