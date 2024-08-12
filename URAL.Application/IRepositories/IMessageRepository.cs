using URAL.Domain.Entities;

namespace URAL.Application.IRepositories;

public interface IMessageRepository : IBaseRepository<Message>
{
    public IQueryable<Message> GetByUserId(string userId);
    public IQueryable<Message> GetByChatId(long chatId);
}