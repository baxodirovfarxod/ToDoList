using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Bll.DTOs;
using ToDoList.Dal.Entity;
using ToDoList.Repository.ToDoItemRepository;

namespace ToDoList.Bll.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _toDoItemRepository;

        public ToDoItemService(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        public async Task DeleteToDoItemByIdAsync(long id)
        {
            var item = await _toDoItemRepository.SelectToDoItemByIdAsync(id);
            if (item is null)
            {
                throw new ArgumentNullException($"ToDoItem with id {id} not found.");
            }
            await _toDoItemRepository.DeleteToDoItemByIdAsync(id);
        }

        public Task<long> AddToDoItemAsync(ToDoItemCreateDto toDoItemCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDoItemGetDto>> GetAllToDoItemsAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDoItemGetDto>> GetByDueDateAsync(DateTime dueDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDoItemGetDto>> GetCompletedAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDoItemGetDto>> GetIncompleteAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoItemGetDto> GetToDoItemByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoItemGetDto> UpdateToDoItemAsync(ToDoItemGetDto newItem)
        {
            throw new NotImplementedException();
        }
    }

}
