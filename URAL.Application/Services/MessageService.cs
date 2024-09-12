using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using URAL.Application.Base;
using URAL.Application.Hasher;
using URAL.Application.IRepositories;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Message;
using URAL.Domain.Entities;

namespace URAL.Application.Services;

public class MessageService(IMapper mapper, IMessageRepository repository, IHasher hasher) : IMessageService
{
    private int PageSize { get; } = 8;
    public async Task<PaginatedList<MessageToGet>> GetAllAsync(int pageNumber)
    {
        var result = repository.GetAll().Include(m => m.User).Select(x => new MessageToGet
        {
            Id = x.Id,
            UserId = x.UserId,
            UserName = x.User.UserName,
            ChatId = x.ChatId,
            Content = hasher.Decode(x.Content),
            SentAt = x.SentAt
        });
        var messages = PaginatedList<MessageToGet>.Create(result, pageNumber, PageSize);
        return await messages;
    }

    public async Task<PaginatedList<MessageToGet>> GetByUserIdAsync(string userId, int pageNumber)
    {
        var result = repository.GetByUserId(userId).Include(m => m.User)
            .Select(x =>  new MessageToGet {
                Id = x.Id,
                UserId = x.UserId,
                UserName = x.User.UserName,
                ChatId = x.ChatId,
                Content = hasher.Decode(x.Content),
                SentAt = x.SentAt
            });
        
        var messages = PaginatedList<MessageToGet>.Create(result, pageNumber, PageSize);
        return await messages;
    }

    public async Task<PaginatedList<MessageToGet>> GetByChatIdAsync(long chatId, int pageNumber)
    {
        var result = repository.GetByChatId(chatId).Include(m => m.User).Select(x => new MessageToGet
        {
            Id = x.Id,
            UserId = x.UserId,
            UserName = x.User.UserName,
            ChatId = x.ChatId,
            Content = hasher.Decode(x.Content),
            SentAt = x.SentAt,
        });
        
        var messages = PaginatedList<MessageToGet>.Create(result, pageNumber, PageSize);
        return await messages;
    }

    public MessageToGet? GetById(long id)
    {
        var entity = repository.GetById(id);

        if (entity is null)
            return null;

        var message = new MessageToGet
        {
            Id = entity.Id,
            UserId = entity.UserId,
            UserName = entity.User.UserName,
            ChatId = entity.ChatId,
            Content = hasher.Decode(entity.Content),
            SentAt = entity.SentAt
        };
        return message;
    }

    public async Task<long> AddAsync(MessageToAdd message, string userId)
    {
        var entity = mapper.Map<MessageToAdd, Message>(message);
        entity.UserId = userId;
        entity.SentAt = DateTime.UtcNow;
        entity.Content = hasher.Encode(message.Content);
        entity = await repository.AddAsync(entity);
        await repository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(MessageToUpdate message)
    {
        var entity = repository.GetById(message.Id);
        message.Content = hasher.Encode(message.Content);
        if (entity is null)
            return false;

        mapper.Map(message, entity);
        repository.Update(entity);

        await repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(MessageToDelete message)
    {
        var entity = repository.GetById(message.Id);

        if (entity is null)
            return false;
        
        repository.Delete(entity);
        await repository.SaveChangesAsync();
        return true;
    }
}