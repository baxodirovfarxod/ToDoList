using Microsoft.AspNetCore.Mvc.Filters;
using ToDoList.Bll.Services;

namespace ToDoList.Server.Filters;

public class ToDoListCountHeaderFilter : IAsyncResultFilter
{

    private readonly IToDoItemService _toDoItemService;

    public ToDoListCountHeaderFilter(IToDoItemService toDoItemService)
    {
        _toDoItemService = toDoItemService;
    }

    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var totalCount = await _toDoItemService.GetTotalCountAsync();

        context.HttpContext.Response.Headers.Add("X-Total-Count", totalCount.ToString());

        await next();
    }
}


