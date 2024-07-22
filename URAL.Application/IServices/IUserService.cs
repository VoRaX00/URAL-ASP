using URAL.Application.Base;
using URAL.Application.RequestModels.User;

namespace URAL.Application.IServices;

public interface IUserService
{
    Task<string> AddAsync(UserToAdd userToAdd);
    Task UpdateAsync(UserToUpdate userToUpdate);
    Task DeleteAsync(UserToDelete userToDelete);
    public Task<PaginatedList<UserToGet>> GetAllAsync(int pageSize);
    public Task<UserToGet> GetByIdAsync(string id);
    public Task<string> GenerateEmailConfirmationTokenAsync(string id);
    public Task<bool> ConfirmEmailAsync(string id, string code);
}
