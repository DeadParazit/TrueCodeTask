using TrueCodeUlanYeskendirovTask.Core.Models;
using TrueCodeUlanYeskendirovTask.Service.DTOs;

namespace TrueCodeUlanYeskendirovTask.Service.Services.Interfaces;

public interface IPriorityService
{
    Task<List<int>> GetPrioritiesAsync();
    Task AddPriorityAsync(int id);
    Task DeletePriorityAsync(int id);
}