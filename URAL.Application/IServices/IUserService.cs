using URAL.Application.Base;
using URAL.Application.RequestModels.User;

namespace URAL.Application.IServices;

public interface IUserService
{
    Task<string> AddAsync(UserToAdd userToAdd);
    Task<bool> UpdateAsync(UserToUpdate userToUpdate);
    Task<bool> DeleteAsync(UserToDelete userToDelete);
    public Task<PaginatedList<UserToGet>> GetAllAsync(int pageSize);
    public Task<UserToGet?> GetByIdAsync(string id);
    public Task<string> GenerateEmailConfirmationTokenAsync(string id);
    public Task<bool> ConfirmEmailAsync(string id, string code);
    public Task<bool> CheckLoginAsync(UserLogin userLogin);
    public Task<UserToGet?> GetByEmail(string email);
}
