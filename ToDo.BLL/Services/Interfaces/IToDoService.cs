using ToDo.BLL.Models.Dto;
using ToDoApp.Models.Dto;

namespace ToDo.BLL.Services.Interfaces;

public interface IToDoService
{
    Task<ReadToDoItemDto> CreateToDoItemAsync(
        CreateToDoItemDto toDoItem);

    Task<IEnumerable<ReadToDoItemDto>> GetToDoItemsAsync();
    
    Task<ReadToDoItemDto?> GetToDoItemByIdAsync(
        Guid id);
    
    Task<ReadToDoItemDto> UpdateToDoItemAsync(
        UpdateToDoItemDto toDoItem);
    
    Task DeleteToDoItemAsync(
        Guid id);
}