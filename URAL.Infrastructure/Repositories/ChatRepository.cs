using URAL.Application.IRepositories;
using URAL.Domain.Entities;
using URAL.Infrastructure.Context;

namespace URAL.Infrastructure.Repositories;

public class ChatRepository : BaseRepository<Chat>, IChatRepository
{
    public ChatRepository(UralDbContext context)
    {
        _context = context;
    }

    public IQueryable<Chat> GetByFirstUserId(string userId)
    {
        return _context.Chats.Where(chat => chat.FirstUserId == userId);
    }

    public IQueryable<Chat> GetBySecondUserId(string userId)
    {
        return _context.Chats.Where(chat => chat.SecondUserId == userId);
    }

    public IQueryable<Chat> GetByUserId(string userId)
    {
        return _context.Chats.Where(chat => chat.FirstUserId == userId || chat.SecondUserId == userId);
    }
}