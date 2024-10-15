using AutoMapper;
using ToDo.BLL.Models.Dto;
using ToDo.BLL.Services.Interfaces;
using ToDo.DAL.Entity;
using ToDo.DAL.Repositories;
using ToDoApp.Models.Dto;

namespace ToDo.BLL.Services.Implementations;

public class ToDoService(IToDoRepository toDoItemRepository, IMapper mapper) : IToDoService
{
    public async Task<ReadToDoItemDto> CreateToDoItemAsync(CreateToDoItemDto toDoItem)
    {
        if (toDoItem == null) throw new ArgumentNullException(nameof(toDoItem));

        var toDoItemEntity = mapper.Map<ToDoItem>(toDoItem);
        toDoItemEntity.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
        toDoItemEntity.ItemStatus = ItemStatus.Active;
        toDoItemEntity = await toDoItemRepository.AddTodoAsync(toDoItemEntity);
        var toDoItemResult = mapper.Map<ReadToDoItemDto>(toDoItemEntity);
        return toDoItemResult;
    }

    public async Task<IEnumerable<ReadToDoItemDto>> GetToDoItemsAsync()
    {
        var items = await toDoItemRepository.GetAllTodosAsync();
        return mapper.Map<IEnumerable<ReadToDoItemDto>>(items);
    }

    public async Task<ReadToDoItemDto?> GetToDoItemByIdAsync(Guid id)
    {
        var item = await toDoItemRepository.GetTodoByIdAsync(id);
        return item == null ? null : mapper.Map<ReadToDoItemDto>(item);
    }
    public async Task<ReadToDoItemDto> UpdateToDoItemAsync(UpdateToDoItemDto toDoItem)
    {
        if (toDoItem == null) throw new ArgumentNullException(nameof(toDoItem));
        if (!await toDoItemRepository.ExistsAsync(toDoItem.Id))
        {
            throw new KeyNotFoundException("");
        }

        var toDoItemEntity = mapper.Map<ToDoItem>(toDoItem);
        toDoItemEntity = await toDoItemRepository.UpdateTodoAsync(toDoItemEntity);
        return mapper.Map<ReadToDoItemDto>(toDoItemEntity);
    }
    
    public async Task DeleteToDoItemAsync(Guid id)
    {
        if (!await toDoItemRepository.ExistsAsync(id))
        {
            throw new KeyNotFoundException("");
        }
        await toDoItemRepository.DeleteTodoAsync(id);
    }
}