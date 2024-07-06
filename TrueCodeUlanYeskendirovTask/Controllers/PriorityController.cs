using Microsoft.AspNetCore.Mvc;
using TrueCodeUlanYeskendirovTask.Service.Services.Interfaces;

namespace TrueCodeUlanYeskendirovTask.Controllers;

[ApiController] 
[Route("api/[controller]")]
public class PriorityController : Controller
{
    private readonly IPriorityService _priorityService;

    public PriorityController(IPriorityService priorityService)
    {
        _priorityService = priorityService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPriorities()
    {
        var priorities = await _priorityService.GetPrioritiesAsync();
        return Ok(priorities);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePriority([FromBody] int levelPriority)
    {
        await _priorityService.AddPriorityAsync(levelPriority);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePriority(int id)
    {
        await _priorityService.DeletePriorityAsync(id);
        return Ok();
    }
}