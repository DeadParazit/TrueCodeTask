using TrueCodeUlanYeskendirovTask.Core.Models;
using TrueCodeUlanYeskendirovTask.Service.DTOs;

namespace TrueCodeUlanYeskendirovTask.Service.Services.Interfaces;

public interface ITaskService
{
    Task<List<ToDoItemDto>> GetToDoItemsAsync(GetToDoListFilterDto filterDto);
    Task<ToDoItemDto> GetToDoItemAsync(Guid id);
    Task AddToDoItemAsync(AddToDoItemDto toDoItem);
    Task UpdateToDoItemAsync(UpdateToDoItemDto toDoItem);
    Task DeleteToDoItemAsync(Guid id);
    Task AssignTaskToUserAsync(Guid taskId, Guid userId);
}