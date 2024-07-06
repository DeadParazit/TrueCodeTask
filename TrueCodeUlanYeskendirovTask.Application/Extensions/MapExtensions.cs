using TrueCodeUlanYeskendirovTask.Core.Models;
using TrueCodeUlanYeskendirovTask.Service.DTOs;

namespace TrueCodeUlanYeskendirovTask.Service.Extensions;

public static class MapExtensions
{
    public static UserDto MapEntityToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name
        };
    }
    
    public static ToDoItemDto MapEntityToDto(this ToDoItem toDoItem)
    {
        return new ToDoItemDto
        {
            Id = toDoItem.Id,
            Title = toDoItem.Title,
            Description = toDoItem.Description,
            IsCompleted = toDoItem.IsCompleted,
            DueDate = toDoItem.DueDate,
            PriorityLevel = toDoItem.PriorityId,
            User = toDoItem.User?.MapEntityToDto()
        };
    }
}