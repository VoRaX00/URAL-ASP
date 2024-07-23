using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using URAL.Application.Base;
using URAL.Application.Hasher;
using URAL.Application.IServices;
using URAL.Application.RequestModels.User;
using URAL.Domain.Entities;

namespace URAL.Application.Services;

public class UserService(IMapper mapper, UserManager<User> userManager) : IUserService
{
    public int PageSize { get; } = 4;

    public async Task<string> AddAsync(UserToAdd userToAdd)
    {
        var entity = mapper.Map<UserToAdd, User>(userToAdd);
        entity.DateJoined = DateTime.Now;
        var result = await userManager.CreateAsync(entity, userToAdd.Password);

        if (!result.Succeeded)
            foreach (IdentityError error in result.Errors)
                Console.WriteLine($"Oops! {error.Description} {error.Code}");

        return entity.Id;
    }

    public async Task<bool> ConfirmEmailAsync(string id, string code)
    {
        var entity = await userManager.FindByIdAsync(id);
        var result = await userManager.ConfirmEmailAsync(entity, code);
        return result.Succeeded;
    }

    public async Task DeleteAsync(UserToDelete userToDelete)
    {
        var entity = mapper.Map<UserToDelete, User>(userToDelete);
        await userManager.DeleteAsync(entity);
    }

    public async Task<string> GenerateEmailConfirmationTokenAsync(string id)
    {
        var entity = new User { Id = id };
        return await userManager.GenerateEmailConfirmationTokenAsync(entity);
    }

    public async Task<PaginatedList<UserToGet>> GetAllAsync(int pageNumber)
    {
        var result = userManager.Users.Select(x => mapper.Map<User, UserToGet>(x));
        var users = PaginatedList<UserToGet>.Create(result, pageNumber, PageSize);  
        return await users;
    }

    public async Task<UserToGet> GetByIdAsync(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        return mapper.Map<User, UserToGet>(user);
    }

    public async Task UpdateAsync(UserToUpdate userToUpdate)
    {
        var entity = await userManager.FindByIdAsync(userToUpdate.Id);
        mapper.Map(userToUpdate, entity);
        await userManager.UpdateAsync(entity);
    }
}
