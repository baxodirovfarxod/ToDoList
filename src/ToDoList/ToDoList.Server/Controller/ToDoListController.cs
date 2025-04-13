using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Bll.DTOs;
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

        [HttpGet("getCompleted")]
        public Task<List<ToDoItemGetDto>> GetCompletedAsync(int skip, int take)
        {
            return _toDoItemService.GetCompletedAsync(skip, take);
        }

        [HttpGet("getAllToDoItems")]
        public Task<List<ToDoItemGetDto>> GetAllToDoItemsAsync(int skip, int take)
        {
            return _toDoItemService.GetAllToDoItemsAsync(skip, take);
        }
    }
}
