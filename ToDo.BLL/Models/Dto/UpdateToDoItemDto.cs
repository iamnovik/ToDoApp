using ToDo.DAL.Entity;

namespace ToDo.BLL.Models.Dto;

public class UpdateToDoItemDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public ItemStatus ItemStatus { get; set; }
    public DateOnly CreatedAt { get; set; }
}