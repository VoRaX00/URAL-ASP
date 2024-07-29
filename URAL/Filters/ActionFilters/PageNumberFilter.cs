using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace URAL.Filters.ActionFilters
{
    public class PageNumberFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.TryGetValue("pageNumber", out var pageNumberObject))
                context.Result = new ContentResult() { StatusCode = 400, Content = "не указан pageNumber" };

            if (pageNumberObject is int pageNumber)
            {
                if (pageNumber < 1)
                    context.Result = new ContentResult() { StatusCode=400, Content= "отсчет страниц идет с 1" };
            }
        }
    }
}
