using Microsoft.EntityFrameworkCore;
using TrueCodeUlanYeskendirovTask.Core.Models;
using TrueCodeUlanYeskendirovTask.Repository.Repositories;
using TrueCodeUlanYeskendirovTask.Service.DTOs;
using TrueCodeUlanYeskendirovTask.Service.Extensions;
using TrueCodeUlanYeskendirovTask.Service.Services.Interfaces;

namespace TrueCodeUlanYeskendirovTask.Service.Services.Implemetations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserDto>> GetUsersAsync()
    {
        return (await _userRepository.GetAllAsync()).Select(x => x.MapEntityToDto()).ToList();
    }

    public async Task<UserDto> GetUserAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            throw new Exception("User not found");
        
        return user.MapEntityToDto();
    }

    public async Task AddUserAsync(string name)
    {
        if(name.Length > 80)
            throw new ArgumentException("Name length should be less than 80 characters");
        
        await _userRepository.AddAsync(new User { Name = name });
    }

    public async Task UpdateUserAsync(UserDto dto)
    {
        if(dto.Name.Length > 80)
            throw new ArgumentException("Name length should be less than 80 characters");
        
        var user = await _userRepository.GetByIdAsync(dto.Id);
        
        if (user == null)
            throw new Exception("User not found");
        
        user.Name = dto.Name;
        
        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(Guid id)
    {
        await _userRepository.DeleteAsync(id);
    }
}