namespace URAL.Application.RequestModels.User;

public record UserToChangePassword(string Email, string CurrentPassword, string NewPassword);
