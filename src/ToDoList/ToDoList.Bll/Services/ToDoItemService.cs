using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Dal.Entity;

namespace ToDoList.Bll.Services
{
    public class ToDoItemService : IToDoItemService
    {
        
        public List<ToDoItem> SelectByDueDateAsync(DateTime dueDate)
        {
            throw new NotImplementedException();
        }

        public ToDoItem SelectToDoItemByIdAsync(ToDoItem toDoItem)
        {
            throw new NotImplementedException();
        }

        public List<ToDoItem> SelectAllToDoItemsAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task InsertToDoItemAsync(ToDoItem toDoItem)
        {
            throw new NotImplementedException();
        }

        public Task<long> DeleteToDoItemByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoItem> UpdateToDoItemAsync(ToDoItem oldItem, ToDoItem newItem)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDoItem>> SelectCompletedAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDoItem>> SelectIncompleteAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }
    }
}
