namespace TrueCodeUlanYeskendirovTask.Service.DTOs;

public class ToDoItemDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
    
    public int? PriorityLevel { get; set; }
    
    public UserDto? User { get; set; }
}