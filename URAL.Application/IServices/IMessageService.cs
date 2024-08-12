using URAL.Application.RequestModels.Message;
using URAL.Domain.Entities;

namespace URAL.Application.IServices;

public interface IMessageService
{
    public Task<bool> SendAsync(Message message);
    public Task<bool> DeleteAsync(MessageToDelete message);
}