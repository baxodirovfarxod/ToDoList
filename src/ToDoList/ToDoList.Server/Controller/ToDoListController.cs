using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Bll.Services;

namespace ToDoList.Server.Controller
{
    [Route("api/toDoList")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoItemService _toDoItemService;

        public ToDoListController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        [HttpDelete("delete")]
        public async Task DeleteToDoItemByIdAsync(long id)
        {
            await _toDoItemService.DeleteToDoItemByIdAsync(id);
        }
    }
}
