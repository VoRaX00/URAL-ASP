using URAL.Application.Base;
using URAL.Application.RequestModels.User;

namespace URAL.Application.IServices;

public interface IUserService
{
    Task<ulong> AddAsync(UserToAdd userToAdd);
    Task UpdateAsync(UserToUpdate userToUpdate);
    Task DeleteAsync(UserToDelete userToDelete);
    public Task<PaginatedList<UserToGet>> GetAllAsync(int pageSize);
    public UserToGet GetById(ulong id);
}
