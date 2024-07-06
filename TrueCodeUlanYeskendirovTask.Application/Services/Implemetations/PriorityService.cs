using TrueCodeUlanYeskendirovTask.Core.Models;
using TrueCodeUlanYeskendirovTask.Repository.Repositories;
using TrueCodeUlanYeskendirovTask.Service.Services.Interfaces;

namespace TrueCodeUlanYeskendirovTask.Service.Services.Implemetations;

public class PriorityService : IPriorityService
{
    private readonly IPriorityRepository _priorityRepository;

    public PriorityService(IPriorityRepository priorityRepository)
    {
        _priorityRepository = priorityRepository;
    }

    public async Task<List<int>> GetPrioritiesAsync()
    {
        return (await _priorityRepository.GetAllAsync()).Select(x => x.Level).ToList();
    }

    public async Task AddPriorityAsync(int id)
    {
        if(id <= 0)
            throw new ArgumentException("Priority level should be greater than 0");
        
        await _priorityRepository.AddAsync(new Priority { Level = id });
    }

    public async Task DeletePriorityAsync(int id)
    {
        await _priorityRepository.DeleteAsync(id);
    }
}