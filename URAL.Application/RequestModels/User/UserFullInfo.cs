namespace URAL.Application.RequestModels.User
{
    public class UserFullInfo
    {
        public string Id { get; set; }
        public string UserName { get; init; }
        public string Email { get; init; }
        public ulong? PhoneNumber { get; init; }
        public string AboutMe { get; set; }
        public string Image { get; set; }
        public bool IsStaff { get; set; }
        public bool IsSuperuser { get; set; }
        public bool EmailConfirmed { get; init; }
        public DateTime DateJoined { get; init; }
        public DateTime? LastLogin { get; init; }
    }
}
