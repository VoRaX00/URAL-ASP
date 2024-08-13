using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using URAL.Application.Base;
using URAL.Application.IRepositories;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Chat;
using URAL.Domain.Entities;

namespace URAL.Application.Services;

public class ChatService(IMapper mapper, IChatRepository repository) : IChatService
{
    public async Task<List<ChatToGet>> GetByFirstUserIdAsync(string userId)
    {
        var result = repository.GetByFirstUserId(userId).Select(x => mapper.Map<Chat, ChatToGet>(x));
        var chats = result.ToListAsync();
        return await chats;
    }

    public async Task<List<ChatToGet>> GetBySecondUserIdAsync(string userId)
    {
        var result = repository.GetBySecondUserId(userId).Select(x => mapper.Map<Chat, ChatToGet>(x));
        var chats = result.ToListAsync();
        return await chats;
    }

    public async Task<List<ChatToGet>> GetAllAsync()
    {
        var result = repository.GetAll().Select(x => mapper.Map<Chat, ChatToGet>(x));
        var chats = result.ToListAsync();
        return await chats;
    }

    public ChatToGet? GetById(long id)
    {
        var entity = repository.GetById(id);

        if (entity is null)
            return null;

        return mapper.Map<Chat, ChatToGet>(entity);
    }

    public async Task<long> AddAsync(ChatToAdd chat)
    {
        var entity = mapper.Map<ChatToAdd, Chat>(chat);
        entity = await repository.AddAsync(entity);
        await repository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(ChatToUpdate chat)
    {
        var entity = repository.GetById(chat.Id);

        if (entity is null)
            return false;

        mapper.Map(chat, entity);
        repository.Update(entity);

        await repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(ChatToDelete chat)
    {
        var entity = repository.GetById(chat.Id);

        if (entity is null)
            return false;
        
        repository.Delete(entity);
        await repository.SaveChangesAsync();
        return true;
    }
}