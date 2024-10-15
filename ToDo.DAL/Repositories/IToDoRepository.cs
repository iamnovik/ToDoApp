using ToDo.DAL.Entity;

namespace ToDo.DAL.Repositories;

public interface IToDoRepository
{
    Task<IEnumerable<ToDoItem?>> GetAllTodosAsync();
    Task<ToDoItem?> GetTodoByIdAsync(Guid id);
    Task<ToDoItem> AddTodoAsync(ToDoItem todo);
    Task<ToDoItem> UpdateTodoAsync(ToDoItem todo);
    Task<bool> ExistsAsync(Guid id);
    Task DeleteTodoAsync(Guid id);
}