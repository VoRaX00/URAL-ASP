using URAL.Application.Base;
using URAL.Application.RequestModels.Message;
using URAL.Domain.Entities;

namespace URAL.Application.IServices;

public interface IMessageService
{
    public Task<PaginatedList<MessageToGet>> GetAllAsync(int pageNumber);
    public Task<PaginatedList<MessageToGet>> GetByUserIdAsync(string userId, int pageNumber);
    public Task<PaginatedList<MessageToGet>> GetByChatIdAsync(long chatId, int pageNumber);
    public MessageToGet? GetById(long id);
    Task<long> AddAsync(MessageToAdd message);
    Task<bool> UpdateAsync(MessageToUpdate message);
    Task<bool> DeleteAsync(MessageToDelete message);
}