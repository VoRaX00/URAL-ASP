using URAL.Application.Base;
using URAL.Application.RequestModels.User;

namespace URAL.Application.IServices;

public interface IUserService
{
    Task<ulong> AddAsync(UserToAdd userToAdd);
    Task AddRangeAsync(IEnumerable<UserToAdd> entities);
    void Update(UserToUpdate userToUpdate);
    void UpdateRange(IEnumerable<UserToUpdate> entities);
    void Delete(UserToDelete userToDelete);
    void DeleteRange(IEnumerable<UserToDelete> entities);
    public PaginatedList<UserToGet> GetAll();
    public UserToGet GetByID(ulong id);
}
