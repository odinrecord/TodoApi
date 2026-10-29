using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using TodoApi.Dtos;
using TodoApi.Models;


namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    public static readonly ConcurrentDictionary<Guid, Todo> _todos = new();

    [HttpPost]
    public ActionResult<Todo> CreateTodo([FromBody] CreateTodoDto createDto)
    {
        if (string.IsNullOrWhiteSpace(createDto.Title))
        {
            return NotFound(new { Message = "Title is required." });
        }

        var newTodo = new Todo
        {
            Title = createDto.Title,
            Description = createDto.Description,
            Priority = createDto.Priority,
            DueDate = createDto.DueDate,
            Category = createDto.Category,
            IsCompleted = false,
            CreatedAt = DateTime.UtcNow
        };

        _todos.TryAdd(newTodo.Id, newTodo);

        return Ok("Created successfully");
    }

    [HttpGet("search")]
    public IActionResult SearchTodoAsync(
        [FromQuery] bool isCompleted,
        [FromQuery] PriorityLevel priority
    )
    {
        var result = _todos.Values.Select(
            x => x.IsCompleted == isCompleted & x.Priority == priority);
        return Ok(result);
    }
}