using ToDoApp.Models;

namespace ToDoApp.Services;

public interface IToDoService
{
    Task<ToDoItem?> CreateToDoItemAsync(
        ToDoItem toDoItem);

    Task<IEnumerable<ToDoItem>> GetToDoItemsAsync();
    
    Task<ToDoItem?> GetToDoItemByIdAsync(
        Guid id);
    
    Task<ToDoItem?> UpdateToDoItemAsync(
        ToDoItem toDoItem);
    
    Task DeleteToDoItemAsync(
        Guid id);
}