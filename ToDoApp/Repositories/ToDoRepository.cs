using Microsoft.EntityFrameworkCore;
using ToDoApp.Context;
using ToDoApp.Models;

namespace ToDoApp.Repositories;

public class ToDoRepository(AppDbContext _context) : IToDoRepository
{
    public async Task<IEnumerable<ToDoItem?>> GetAllTodosAsync()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task<ToDoItem?> GetTodoByIdAsync(Guid id)
    {
        return await _context.Items.FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public async Task<ToDoItem> AddTodoAsync(ToDoItem todo)
    {
        var entityEntry = await _context.Items.AddAsync(todo);
        await _context.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<ToDoItem> UpdateTodoAsync(ToDoItem todo)
    {
        var entityEntry = _context.Items.Update(todo);
        await _context.SaveChangesAsync(); 
        return entityEntry.Entity;
    }
    public async Task<bool> ExistsAsync(Guid id)
    {
        return _context.Items.AsNoTracking().Any(ToDoItem => ToDoItem.Id == id);
    }
    public async Task DeleteTodoAsync(Guid id)
    {
        var entity = await _context.Items.FindAsync(id);
        if (entity != null)
        {
            _context.Items.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}