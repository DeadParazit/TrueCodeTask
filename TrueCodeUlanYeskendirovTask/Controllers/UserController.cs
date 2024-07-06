using Microsoft.AspNetCore.Mvc;
using TrueCodeUlanYeskendirovTask.Service.DTOs;
using TrueCodeUlanYeskendirovTask.Service.Services.Interfaces;

namespace TrueCodeUlanYeskendirovTask.Controllers;

[ApiController] 
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var user = await _userService.GetUserAsync(id);
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetUsersAsync();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] string name)
    {
        await _userService.AddUserAsync(name);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] string name)
    {
        await _userService.UpdateUserAsync(new UserDto()
        {
            Id = id,
            Name = name
        });
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await _userService.DeleteUserAsync(id);
        return Ok();
    }
    
}