using ToDoList.Dal.Entity;

namespace ToDoList.Repository.ToDoItemRepository;

public interface IToDoItemRepository
{
    Task InsertToDoItemAsync(ToDoItem toDoItem);
    Task DeleteToDoItemByIdAsync(long id);
    Task UpdateToDoItemAsync(ToDoItem toDoItem);
    Task<ICollection<ToDoItem>> SelectAllToDoItemsAsync(int skip, int take);
    Task<ToDoItem> SelectToDoItemByIdAsync(long id);
    Task<ICollection<ToDoItem>> SelectByDueDateAsync(DateTime dueDate, int skip, int take);
    Task<ICollection<ToDoItem>> SelectCompletedAsync(int skip, int take);
    Task<ICollection<ToDoItem>> SelectIncompleteAsync(int skip, int take);
}


