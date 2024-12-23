﻿using URAL.Application.Base;
using URAL.Application.RequestModels.NotifyCargo;

namespace URAL.Application.IServices;

public interface INotifyCargoService
{
    public Task<PaginatedList<NotifyCargoToGet>> GetAllAsync(int pageNumber);
    public NotifyCargoToGet? GetById(long id);
    Task<long> AddAsync(NotifyCargoToAdd notifyCargoToAdd);
    Task<bool> UpdateAsync(NotifyCargoToUpdate notifyCargoToUpdate);
    Task<bool> DeleteAsync(NotifyCargoToDelete notifyCargoToDelete);
    public Task<PaginatedList<NotifyCargoToGet>> GetUserMatchAsync(string userId, int pageNumber);
    public Task<PaginatedList<NotifyCargoToGet>> GetUserNotificationsAsync(string userId, int pageNumber);
    public Task<PaginatedList<NotifyCargoToGet>> GetUserResponsesAsync(string userId, int pageNumber);
}
