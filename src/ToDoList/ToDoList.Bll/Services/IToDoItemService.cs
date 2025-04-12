using ToDoList.Bll.DTOs;

namespace ToDoList.Bll.Services
{
    public interface IToDoItemService
    {
        Task<List<ToDoItemGetDto>> SelectByDueDateAsync(DateTime dueDate);
        Task<ToDoItemGetDto> SelectToDoItemByIdAsync(long id);
        Task<List<ToDoItemGetDto>> SelectAllToDoItemsAsync(int skip, int take);
        Task<long> InsertToDoItemAsync(ToDoItemCreateDto toDoItem);
        Task DeleteToDoItemByIdAsync(long id);
        Task UpdateToDoItemAsync(ToDoItemUpdateDto newItem);
        Task<List<ToDoItemGetDto>> SelectCompletedAsync(int skip, int take);
        Task<List<ToDoItemGetDto>> SelectIncompleteAsync(int skip, int take);

    }
}
