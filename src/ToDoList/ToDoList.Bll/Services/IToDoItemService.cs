using ToDoList.Bll.DTOs;
using ToDoList.Dal.Entity;

namespace ToDoList.Bll.Services
{
    public interface IToDoItemService
    {
        List<ToDoItemGetDto> SelectByDueDateAsync(DateTime dueDate);
        ToDoItemGetDto SelectToDoItemByIdAsync(ToDoItem toDoItem);
        List<ToDoItemGetDto> SelectAllToDoItemsAsync(int skip, int take);
        Task InsertToDoItemAsync(ToDoItem toDoItem);
        Task<long> DeleteToDoItemByIdAsync(long id);
        Task<ToDoItemGetDto> UpdateToDoItemAsync(ToDoItem oldItem, ToDoItem newItem);
        Task<List<ToDoItemGetDto>> SelectCompletedAsync(int skip, int take);
        Task<List<ToDoItemGetDto>> SelectIncompleteAsync(int skip, int take);

    }
}
