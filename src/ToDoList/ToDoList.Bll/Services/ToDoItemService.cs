using FluentValidation;
using ToDoList.Bll.DTOs;
using ToDoList.Dal.Entity;
using ToDoList.Repository.ToDoItemRepository;

namespace ToDoList.Bll.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _toDoItemRepository;
        private readonly IValidator<ToDoItemCreateDto> _toDoItemCreateDtoValidator;

        public ToDoItemService(IToDoItemRepository toDoItemRepository, IValidator<ToDoItemCreateDto> validator)
        {
            _toDoItemRepository = toDoItemRepository;
            _toDoItemCreateDtoValidator = validator;
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

        public async Task<long> AddToDoItemAsync(ToDoItemCreateDto toDoItem)
        {
            var validationResult = _toDoItemCreateDtoValidator.Validate(toDoItem);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            ArgumentNullException.ThrowIfNull(toDoItem);
            var covert = ConvertCreateDtoToEntity(toDoItem);


            var id = await _toDoItemRepository.InsertToDoItemAsync(covert);
            return id;

        }

        public async Task<List<ToDoItemGetDto>> GetAllToDoItemsAsync(int skip, int take)
        {
            var toDoItems = await _toDoItemRepository.SelectAllToDoItemsAsync(skip, take);

            var toDoItemDtos = toDoItems
                .Select(item => ConvertToGetDto(item))
                .ToList();

            return toDoItemDtos;
        }

        public async Task<List<ToDoItemGetDto>> GetByDueDateAsync(DateTime dueDate)
        {
            var result = await _toDoItemRepository.SelectByDueDateAsync(dueDate);
            return result.Select(item => ConvertToGetDto(item)).ToList();
        }

        public async Task<List<ToDoItemGetDto>> GetCompletedAsync(int skip, int take)
        {
            var completedItems = await _toDoItemRepository.SelectCompletedAsync(skip, take);

            return completedItems
                       .Select(item => ConvertToGetDto(item))
                       .ToList();
        }

        public async Task<List<ToDoItemGetDto>> GetIncompleteAsync(int skip, int take)
        {
            var incompleteItems = await _toDoItemRepository.SelectIncompleteAsync(skip, take);

            var incompleteDtos = incompleteItems
                .Select(item => ConvertToGetDto(item))
                .ToList();

            return incompleteDtos;
        }

        public async Task<ToDoItemGetDto> GetToDoItemByIdAsync(long id)
        {
            var founded = await _toDoItemRepository.SelectToDoItemByIdAsync(id);
            return ConvertToGetDto(founded);
        }

        public async Task UpdateToDoItemAsync(ToDoItemUpdateDto newItem)
        {
            var existingItem = await _toDoItemRepository.SelectToDoItemByIdAsync(newItem.ToDoItemId);
            if (existingItem == null)
            {
                throw new Exception($"ToDoItem with ID {newItem.ToDoItemId} not found.");
            }

            ConvertToEntity(existingItem, newItem);

            await _toDoItemRepository.UpdateToDoItemAsync(existingItem);
        }

        private void ConvertToEntity(ToDoItem existingItem, ToDoItemUpdateDto newItem)
        {
            existingItem.Title = newItem.Title;
            existingItem.Description = newItem.Description;
            existingItem.IsCompleted = newItem.IsCompleted;
            existingItem.DueDate = newItem.DueDate;
        }

        private ToDoItemGetDto ConvertToGetDto(ToDoItem item)
        {
            var res = new ToDoItemGetDto
            {
                ToDoItemId = item.ToDoItemId,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
                DueDate = item.DueDate,
                CreatedAt = item.CreatedAt,
            };

            return res;
        }
        private ToDoItem ConvertCreateDtoToEntity(ToDoItemCreateDto item)
        {
            var res = new ToDoItem
            {
                Title = item.Title,
                Description = item.Description,
                DueDate = item.DueDate,
                CreatedAt = DateTime.UtcNow
            };

            return res;
        }

        //Task<GetAllResponseModel> IToDoItemService.GetAllToDoItemsAsync(int skip, int take)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
