using ToDoApp.Models;
using ToDoApp.Repositories;

namespace ToDoApp.Services;

public class ToDoService(IToDoRepository toDoRepository) : IToDoService
{
    public async Task<ToDoItem?> CreateToDoItemAsync(ToDoItem toDo)
    {
        toDo.Id = Guid.NewGuid();
        toDo.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
        toDo.ItemStatus = ItemStatus.Active;
        toDo = await toDoRepository.AddTodoAsync(toDo);
        return toDo;
    }

    public async Task<IEnumerable<ToDoItem>> GetToDoItemsAsync()
    {
        var items = await toDoRepository.GetAllTodosAsync();
        return items;
    }

    public async Task<ToDoItem?> GetToDoItemByIdAsync(Guid id)
    {
        var item = await toDoRepository.GetTodoByIdAsync(id);
        return item;
    }

    public async Task<ToDoItem?> UpdateToDoItemAsync(ToDoItem toDoItem)
    {
        if (!await toDoRepository.ExistsAsync(toDoItem.Id))
        {
            throw new KeyNotFoundException("");
        }
        var updateTodoAsync = await toDoRepository.UpdateTodoAsync(toDoItem);
        return updateTodoAsync;
    }

    public async Task DeleteToDoItemAsync(Guid id)
    {
        if (!await toDoRepository.ExistsAsync(id))
        {
            throw new KeyNotFoundException("");
        }
        await toDoRepository.DeleteTodoAsync(id);
    }
}