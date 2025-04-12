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

        public Task<long> InsertToDoItemAsync(ToDoItemCreateDto toDoItemCreateDto)
        {

        }

        public Task<List<ToDoItemGetDto>> SelectAllToDoItemsAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDoItemGetDto>> SelectByDueDateAsync(DateTime dueDate)
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

        public Task<ToDoItemGetDto> SelectToDoItemByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ToDoItemGetDto> UpdateToDoItemAsync(ToDoItemGetDto newItem)
        {
            var existingItem = await _toDoItemRepository.SelectToDoItemByIdAsync(newItem.ToDoItemId);
            if (existingItem == null)
            {
                throw new Exception("Item not found");
            }

            existingItem.Title = newItem.Title;
            existingItem.Description = newItem.Description;
            existingItem.IsCompleted = newItem.IsCompleted;
            existingItem.DueDate = newItem.DueDate;

            await _toDoItemRepository.UpdateToDoItemAsync(existingItem);

            return newItem;
        }
    }

}
