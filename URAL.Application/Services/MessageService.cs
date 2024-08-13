using MapsterMapper;
using URAL.Application.Base;
using URAL.Application.IRepositories;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Message;
using URAL.Domain.Entities;

namespace URAL.Application.Services;

public class MessageService(IMapper mapper, IMessageRepository repository) : IMessageService
{
    public int PageSize { get; } = 8;
    public async Task<PaginatedList<MessageToGet>> GetAllAsync(int pageNumber)
    {
        var result = repository.GetAll().Select(x => mapper.Map<Message, MessageToGet>(x));
        var messages = PaginatedList<MessageToGet>.Create(result, pageNumber, PageSize);
        return await messages;
    }

    public async Task<PaginatedList<MessageToGet>> GetByUserIdAsync(string userId, int pageNumber)
    {
        var result = repository.GetByUserId(userId).Select(x => mapper.Map<Message, MessageToGet>(x));
        var messages = PaginatedList<MessageToGet>.Create(result, pageNumber, PageSize);
        return await messages;
    }

    public async Task<PaginatedList<MessageToGet>> GetByChatIdAsync(long chatId, int pageNumber)
    {
        var result = repository.GetByChatId(chatId).Select(x => mapper.Map<Message, MessageToGet>(x));
        var messages = PaginatedList<MessageToGet>.Create(result, pageNumber, PageSize);
        return await messages;
    }

    public MessageToGet? GetById(long id)
    {
        var entity = repository.GetById(id);

        if (entity is null)
            return null;
        
        return mapper.Map<Message, MessageToGet>(entity);
    }

    public async Task<long> AddAsync(MessageToAdd message, string userId)
    {
        var entity = mapper.Map<MessageToAdd, Message>(message);
        entity.UserId = userId;
        entity.SentAt = DateTime.UtcNow;
        entity = await repository.AddAsync(entity);
        await repository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(MessageToUpdate message)
    {
        var entity = repository.GetById(message.Id);

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