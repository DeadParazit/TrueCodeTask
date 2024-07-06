using Microsoft.EntityFrameworkCore;
using TrueCodeUlanYeskendirovTask.Core.Models;
using TrueCodeUlanYeskendirovTask.Repository.Repositories;
using TrueCodeUlanYeskendirovTask.Service.DTOs;
using TrueCodeUlanYeskendirovTask.Service.Exceptions;
using TrueCodeUlanYeskendirovTask.Service.Extensions;
using TrueCodeUlanYeskendirovTask.Service.Services.Interfaces;

namespace TrueCodeUlanYeskendirovTask.Service.Services.Implemetations;

public class TaskService : ITaskService
{
    private readonly IToDoItemRepository _toDoItemRepository;

    public TaskService(IToDoItemRepository toDoItemRepository)
    {
        _toDoItemRepository = toDoItemRepository;
    }

    public async Task<List<ToDoItemDto>> GetToDoItemsAsync(GetToDoListFilterDto filterDto)
    {
        var query = _toDoItemRepository.AsQueryable();
        
        if(filterDto.IsCompleted != null)
            query = query.Where(x => x.IsCompleted == filterDto.IsCompleted);

        if (filterDto.IsPriorityAscending != null)
        {
            query = filterDto.IsPriorityAscending.Value
                ? query.OrderBy(x => x.Priority.Level)
                : query.OrderByDescending(x => x.Priority.Level);
        }
        
        return await query.Include(x => x.User)
            .Select(x => x.MapEntityToDto())
            .ToListAsync();
    }

    public async Task<ToDoItemDto> GetToDoItemAsync(Guid id)
    {
        var toDoItem = await _toDoItemRepository.GetByIdAsync(id);
        
        if (toDoItem == null)
            throw new CustomNotFoundException($"ToDoItem with id:{id} not found");

        return toDoItem.MapEntityToDto();
    }

    public async Task AddToDoItemAsync(AddToDoItemDto dto)
    {
        if(dto.Title.Length > 50)
            throw new ArgumentException("Title length should be less than 50 characters");
        
        if(dto.Description.Length > 500)
            throw new ArgumentException("Description length should be less than 500 characters");
        
        var toDoItem = new ToDoItem
        {
            Title = dto.Title,
            Description = dto.Description,
            IsCompleted = dto.IsCompleted,
            DueDate = dto.DueDate,
            PriorityId = dto.PriorityId,
            UserId = dto.UserId
        };
        
        await _toDoItemRepository.AddAsync(toDoItem);
    }

    public async Task UpdateToDoItemAsync(UpdateToDoItemDto dto)
    {
        if(dto.Title.Length > 50)
            throw new ArgumentException("Title length should be less than 50 characters");
        
        if(dto.Description.Length > 500)
            throw new ArgumentException("Description length should be less than 500 characters");
        
        var toDoItem = await _toDoItemRepository.GetByIdAsync(dto.Id);
        
        if (toDoItem == null)
            throw new Exception("ToDoItem not found");
        
        toDoItem.Title = dto.Title;
        toDoItem.Description = dto.Description;
        toDoItem.IsCompleted = dto.IsCompleted;
        toDoItem.DueDate = dto.DueDate;
        toDoItem.PriorityId = dto.PriorityId;
        toDoItem.UserId = dto.UserId;
        
        await _toDoItemRepository.UpdateAsync(toDoItem);
    }

    public async Task DeleteToDoItemAsync(Guid id)
    {
        await _toDoItemRepository.DeleteAsync(id);
    }

    public async Task AssignTaskToUserAsync(Guid taskId, Guid userId)
    {
        var toDoItem = await _toDoItemRepository.GetByIdAsync(taskId);
        
        if (toDoItem == null)
            throw new Exception("ToDoItem not found");
        
        toDoItem.UserId = userId;
        
        await _toDoItemRepository.UpdateAsync(toDoItem);
    }
}