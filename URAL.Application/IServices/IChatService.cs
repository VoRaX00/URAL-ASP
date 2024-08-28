using URAL.Application.Base;
using URAL.Application.RequestModels.Chat;

namespace URAL.Application.IServices;

public interface IChatService
{
    public Task<List<ChatToGet>> GetByFirstUserIdAsync(string userId);
    public Task<List<ChatToGet>> GetBySecondUserIdAsync(string userId);
    public Task<List<ChatToGet>> GetByUserIdAsync(string userId);
    public Task<List<ChatToImage>> GetImagesByUserIdAsync(string userId);
    public Task<List<ChatToGet>> GetAllAsync();
    public ChatToGet? GetById(long id);
    Task<long> AddAsync(ChatToAdd chat, string userId);
    Task<bool> UpdateAsync(ChatToUpdate chat);
    Task<bool> DeleteAsync(ChatToDelete chat);
}