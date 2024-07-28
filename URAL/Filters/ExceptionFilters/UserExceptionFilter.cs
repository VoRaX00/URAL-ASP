using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using URAL.Domain.Exceptions;

namespace URAL.Filters.ExceptionFilters;

public class UserExceptionFilter : Attribute, IAsyncExceptionFilter
{
    public Task OnExceptionAsync(ExceptionContext context)
    {
        if (context.Exception is NotValidUserException notValidUserEx)
        {
            context.Result = new JsonResult(new { message="Введены не валидные данные", errors = notValidUserEx.Errors }) { StatusCode= 400 };
        }
        else if (context.Exception is NotFoundUserEmailException notFoundUserEmailEx)
        {
            context.Result = new ContentResult() { StatusCode = 400, Content = $"пользователя с почтой {notFoundUserEmailEx.Email} не существует" };
        }

        return Task.CompletedTask;
    }
}
