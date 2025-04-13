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

        public async Task<List<ToDoItemGetDto>> GetAllToDoItemsAsync(int skip, int take)
        {
            var toDoItems = await _toDoItemRepository.SelectAllToDoItemsAsync(skip, take);

            var toDoItemDtos = toDoItems
                .Select(item => MapToGetDto(item))
                .ToList();

            return toDoItemDtos;
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

        public async Task UpdateToDoItemAsync(ToDoItemUpdateDto newItem)
        {
            var existingItem = await _toDoItemRepository.SelectToDoItemByIdAsync(newItem.ToDoItemId);
            if (existingItem == null)
            {
                throw new Exception($"ToDoItem with ID {newItem.ToDoItemId} not found.");
            }

            MapToEntity(existingItem, newItem);

            await _toDoItemRepository.UpdateToDoItemAsync(existingItem);
        }


        private void MapToEntity(ToDoItem existingItem, ToDoItemUpdateDto newItem)
        {
            existingItem.Title = newItem.Title;
            existingItem.Description = newItem.Description;
            existingItem.IsCompleted = newItem.IsCompleted;
            existingItem.DueDate = newItem.DueDate;
        }


        private ToDoItemGetDto MapToGetDto(ToDoItem item)
        {
            var res = new ToDoItemGetDto
            {
                ToDoItemId = item.ToDoItemId,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
                DueDate = item.DueDate
            };

            return res;
        }


    }

}
