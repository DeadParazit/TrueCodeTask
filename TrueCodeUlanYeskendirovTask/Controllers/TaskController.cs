using Microsoft.AspNetCore.Mvc;
using TrueCodeUlanYeskendirovTask.Core.Models;
using TrueCodeUlanYeskendirovTask.Service.DTOs;
using TrueCodeUlanYeskendirovTask.Service.Services.Interfaces;

namespace TrueCodeUlanYeskendirovTask.Controllers;

/// <summary>
/// Controller for managing tasks.
/// </summary>
[ApiController] 
[Route("api/[controller]")]
public class TaskController : Controller
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    /// <summary>
    /// Updates a task.
    /// </summary>
    /// <param name="toDoItem">The task to update.</param>
    [HttpPut]
    public async Task<IActionResult> PutToDoItem(UpdateToDoItemDto toDoItem)
    {
        await _taskService.UpdateToDoItemAsync(toDoItem);
        
        return Ok();
    }
    
    /// <summary>
    /// Adds a new task.
    /// </summary>
    /// <param name="toDoItem">The task to add.</param>
    [HttpPost]
    public async Task<IActionResult> AddToDoItem(AddToDoItemDto toDoItem)
    {
        await _taskService.AddToDoItemAsync(toDoItem);

        return Ok();
    }
    
    /// <summary>
    /// Deletes a task.
    /// </summary>
    /// <param name="id">The id of the task to delete.</param>
    [HttpDelete]
    public async Task<IActionResult> DeleteToDoItem(Guid id)
    {
        await _taskService.DeleteToDoItemAsync(id);
        
        return Ok();
    }
    
    /// <summary>
    /// Gets a task by id.
    /// </summary>
    /// <param name="id">The id of the task to get.</param>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetToDoItem(Guid id)
    {
        var result = await _taskService.GetToDoItemAsync(id);
        
        return Ok(result);
    }

    /// <summary>
    /// Gets tasks based on a filter.
    /// </summary>
    /// <param name="filter">The filter to apply.</param>
    [HttpGet("filter")]
    public async Task<IActionResult> GetToDoItems([FromQuery] GetToDoListFilterDto filter)
    {
        var result = await _taskService.GetToDoItemsAsync(filter);
        
        return Ok(result);
    }
    
    /// <summary>
    /// Assigns task to user.
    /// </summary>
    /// <param name="taskId">The id of the task to assign.</param>
    /// <param name="userId">The id of the user to whom the task will be assigned.</param>
    [HttpPost("assign")]
    public async Task<IActionResult> AssignTaskToUser(Guid taskId, Guid userId)
    {
        await _taskService.AssignTaskToUserAsync(taskId, userId);
        
        return Ok();
    }
}