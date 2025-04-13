using ToDoList.Dal.Entity;

namespace ToDoList.Repository.ToDoItemRepository;

public class AdoNetToDoItemRepository : IToDoItemRepository
{
    public Task DeleteToDoItemByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<long> InsertToDoItemAsync(ToDoItem toDoItem)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ToDoItem>> SelectAllToDoItemsAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ToDoItem>> SelectByDueDateAsync(DateTime dueDate)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ToDoItem>> SelectCompletedAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ToDoItem>> SelectIncompleteAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<ToDoItem> SelectToDoItemByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateToDoItemAsync(ToDoItem toDoItem)
    {
        throw new NotImplementedException();
    }
}
