using Microsoft.AspNetCore.Mvc;
using ToDo.BLL.Models.Dto;
using ToDo.BLL.Services.Interfaces;
using ToDoApp.Models.Dto;


namespace ToDoApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController(IToDoService _toDoService) : ControllerBase
{
        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            try
            {
                var todos = await _toDoService.GetToDoItemsAsync();
                return Ok(todos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(Guid id)
        {
            try
            {
                var todo = await _toDoService.GetToDoItemByIdAsync(id);
                if (todo == null)
                {
                    return NotFound();
                }
                return Ok(todo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody] CreateToDoItemDto createToDo)
        {
            if (createToDo == null)
            {
                return BadRequest("Invalid request.");
            }

            try
            {
                var createdToDo = await _toDoService.CreateToDoItemAsync(createToDo);
                return CreatedAtAction(nameof(GetTodoById), new { id = createdToDo!.Id }, createdToDo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        public async Task<IActionResult> UpdateTodo([FromBody] UpdateToDoItemDto updatedTodo)
        {
            try
            {
                var updatedToDoItem = await _toDoService.UpdateToDoItemAsync(updatedTodo);
                return Ok(updatedToDoItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            try
            {

                await _toDoService.DeleteToDoItemAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
}