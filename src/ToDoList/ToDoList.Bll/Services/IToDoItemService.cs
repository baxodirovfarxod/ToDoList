using ToDoList.Bll.DTOs;
using ToDoList.Dal.Entity;

namespace ToDoList.Bll.Services
{
    public interface IToDoItemService
    {
        List<ToDoItemGetDto> SelectByDueDateAsync(DateTime dueDate);
        ToDoItemGetDto SelectToDoItemByIdAsync(long id);
        List<ToDoItemGetDto> SelectAllToDoItemsAsync(int skip, int take);
        Task InsertToDoItemAsync(ToDoItemCreateDto toDoItem);
        Task<long> DeleteToDoItemByIdAsync(long id);
        Task<ToDoItemGetDto> UpdateToDoItemAsync(ToDoItemGetDto newItem);
        Task<List<ToDoItemGetDto>> SelectCompletedAsync(int skip, int take);
        Task<List<ToDoItemGetDto>> SelectIncompleteAsync(int skip, int take);

    }
}
