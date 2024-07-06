namespace TrueCodeUlanYeskendirovTask.Service.DTOs;

public class UpdateToDoItemDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public bool IsCompleted { get; set; } = false;
    public DateTime DueDate { get; set; }
    
    public int? PriorityId { get; set; }
    
    public Guid? UserId { get; set; }
}