using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Dal.Entity;

namespace ToDoList.Bll.Services
{
    public interface IToDoItemService
    {
        List<ToDoItem> SelectByDueDateAsync(DateTime dueDate);
        ToDoItem SelectToDoItemByIdAsync(ToDoItem toDoItem);
        List<ToDoItem> SelectAllToDoItemsAsync(int skip, int take);
        Task InsertToDoItemAsync(ToDoItem toDoItem);
        Task<long> DeleteToDoItemByIdAsync(long id);
        Task<ToDoItem>  UpdateToDoItemAsync(ToDoItem oldItem, ToDoItem newItem);
        Task <List<ToDoItem>> SelectCompletedAsync(int skip, int take);
        Task<List<ToDoItem>> SelectIncompleteAsync(int skip, int take);

    }
}
