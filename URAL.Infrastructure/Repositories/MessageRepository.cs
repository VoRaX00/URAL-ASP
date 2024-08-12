using URAL.Application.IRepositories;
using URAL.Domain.Entities;
using URAL.Infrastructure.Context;

namespace URAL.Infrastructure.Repositories;

public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    public MessageRepository(UralDbContext context)
    {
        _context = context;
    }

    public IQueryable<Message> GetByUserId(string userId)
    {
        return _context.Messages.Where(m => m.UserId == userId);
    }

    public IQueryable<Message> GetByChatId(long chatId)
    {
        return _context.Messages.Where(m => m.ChatId == chatId);
    }
}