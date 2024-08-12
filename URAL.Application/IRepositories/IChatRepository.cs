using URAL.Domain.Entities;

namespace URAL.Application.IRepositories;

public interface IChatRepository : IBaseRepository<Chat>
{
    public IQueryable<Chat> GetByFirstUserId(string userId);
    public IQueryable<Chat> GetBySecondUserId(string userId);
}