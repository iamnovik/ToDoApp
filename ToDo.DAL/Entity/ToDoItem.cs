namespace ToDo.DAL.Entity;

public class ToDoItem
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public ItemStatus ItemStatus { get; set; }
    public DateOnly CreatedAt { get; set; }
    
}