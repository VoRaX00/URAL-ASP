using Microsoft.AspNetCore.Identity;
using URAL.Domain.Entities;

namespace URAL.UserValidators;

public class CustomUserNameValidator : IUserValidator<User>
{
    public string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

    public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
    {
        if (user.UserName is null)
            return Task.FromResult(IdentityResult.Failed(new IdentityError() { Description="Имя не может быть null", Code="NullValueInUserName"}));

        var errors = new List<IdentityError>();

        foreach (var c in user.UserName)
        {
            if (!validChars.Contains(c))
                errors.Add(new IdentityError() { Description = $"Имя содержит недопустимый символ {c}", Code = "NotValidChar" });
        }

        return Task.FromResult(errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
    }
}
