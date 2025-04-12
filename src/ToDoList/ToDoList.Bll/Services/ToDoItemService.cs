using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Bll.DTOs;
using ToDoList.Dal.Entity;

namespace ToDoList.Bll.Services
{
    public class ToDoItemService : IToDoItemService
    {
        public Task<long> DeleteToDoItemByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task InsertToDoItemAsync(ToDoItemCreateDto toDoItem)
        {
            throw new NotImplementedException();
        }

        public List<ToDoItemGetDto> SelectAllToDoItemsAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public List<ToDoItemGetDto> SelectByDueDateAsync(DateTime dueDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDoItemGetDto>> SelectCompletedAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDoItemGetDto>> SelectIncompleteAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public ToDoItemGetDto SelectToDoItemByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoItemGetDto> UpdateToDoItemAsync(ToDoItemGetDto newItem)
        {
            throw new NotImplementedException();
        }
    }

}
