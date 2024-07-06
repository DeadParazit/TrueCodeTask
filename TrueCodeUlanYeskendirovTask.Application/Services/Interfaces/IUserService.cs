using TrueCodeUlanYeskendirovTask.Core.Models;
using TrueCodeUlanYeskendirovTask.Service.DTOs;

namespace TrueCodeUlanYeskendirovTask.Service.Services.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetUsersAsync();
    Task<UserDto> GetUserAsync(Guid id);
    Task AddUserAsync(string name);
    Task UpdateUserAsync(UserDto toDoItem);
    Task DeleteUserAsync(Guid id);
}