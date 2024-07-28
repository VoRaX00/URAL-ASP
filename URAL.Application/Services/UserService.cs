using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using URAL.Application.Base;
using URAL.Application.Hasher;
using URAL.Application.IServices;
using URAL.Application.RequestModels.User;
using URAL.Domain.Entities;
using URAL.Domain.Exceptions;

namespace URAL.Application.Services;

public class UserService(IMapper mapper, UserManager<User> userManager) : IUserService
{
    public int PageSize { get; } = 4;

    public async Task<string> AddAsync(UserToAdd userToAdd)
    {
        var entity = mapper.Map<UserToAdd, User>(userToAdd);
        entity.DateJoined = DateTime.Now;
        var isHaveEmail = await userManager.FindByEmailAsync(entity.Email) != null;

        if (isHaveEmail)
            throw new NotValidUserException(
                entity,
                new List<IdentityError>() { new IdentityError() {
                    Description="Пользователь с такой почтой уже существует",
                    Code="Email Duplicate"} });

        var result = await userManager.CreateAsync(entity, userToAdd.Password);

        if (!result.Succeeded)
            throw new NotValidUserException(entity, result.Errors);

        return entity.Id;
    }

    public async Task<bool> CheckLoginAsync(UserLogin userLogin)
    {
        var entity = await userManager.FindByEmailAsync(userLogin.Email);

        if (entity == null)
            throw new NullReferenceException();

        return await userManager.CheckPasswordAsync(entity, userLogin.Password);
    }

    public async Task<bool> ConfirmEmailAsync(string id, string code)
    {
        var entity = await userManager.FindByIdAsync(id);
        var result = await userManager.ConfirmEmailAsync(entity, code);
        return result.Succeeded;
    }

    public async Task<bool> DeleteAsync(UserToDelete userToDelete)
    {
        var entity = await userManager.FindByIdAsync(userToDelete.Id);

        if (entity == null)
            return false;

        var result = await userManager.DeleteAsync(entity);
        return result.Succeeded;
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

    public async Task<UserToGet?> GetByEmail(string email)
    {
        var entity = await userManager.FindByEmailAsync(email);

        if (entity is null)
            return null;

        return mapper.Map<User, UserToGet>(entity);
    }

    public async Task<UserFullInfo?> GetByEmailFullInfo(string email)
    {
        var entity = await userManager.FindByEmailAsync(email);

        if (entity is null)
            return null;

        return mapper.Map<User, UserFullInfo>(entity);
    }

    public async Task<UserToGet?> GetByIdAsync(string id)
    {
        var user = await userManager.FindByIdAsync(id);

        if (user == null)
            return null;

        return mapper.Map<User, UserToGet>(user);
    }

    public async Task<bool> UpdateAsync(UserToUpdate userToUpdate)
    {
        var entity = await userManager.FindByIdAsync(userToUpdate.Id);

        if (entity == null)
            return false;

        mapper.Map(userToUpdate, entity);
        var result = await userManager.UpdateAsync(entity);

        return result.Succeeded;
    }
}
