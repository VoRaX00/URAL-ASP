using MapsterMapper;
using URAL.Application.Base;
using URAL.Application.IRepositories;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Car;
using URAL.Application.RequestModels.Cargo;
using URAL.Application.RequestModels.NotifyCar;
using URAL.Application.RequestModels.NotifyCargo;
using URAL.Application.RequestModels.User;
using URAL.Domain.Entities;

namespace URAL.Application.Services;

public class UserService(IMapper mapper, IUserRepository repository) : IUserService
{
    public int PageSize { get; } = 4;

    public async Task<ulong> AddAsync(UserToAdd userToAdd)
    {
        var entity = mapper.Map<UserToAdd, User>(userToAdd);
        entity = await repository.AddAsync(entity);
        await repository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteAsync(UserToDelete userToDelete)
    {
        var entity = mapper.Map<UserToDelete, User>(userToDelete);
        repository.Delete(entity);
        await repository.SaveChangesAsync();
    }

    public async Task<PaginatedList<UserToGet>> GetAllAsync(int pageNumber)
    {
        var result = repository.GetAll().Select(x => mapper.Map<User, UserToGet>(x));

        var cargo = PaginatedList<UserToGet>.Create(result, pageNumber, PageSize);
        return await cargo;
    }

    public UserToGet GetById(ulong id)
    {
        return mapper.Map<User, UserToGet>(repository.GetById(id));
    }

    public async Task UpdateAsync(UserToUpdate userToUpdate)
    {
        var entity = repository.GetById(userToUpdate.Id);
        mapper.Map(userToUpdate, entity);
        repository.Update(entity);
        await repository.SaveChangesAsync();
    }
}
