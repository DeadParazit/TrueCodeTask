using System.ComponentModel.DataAnnotations.Schema;

namespace TrueCodeUlanYeskendirovTask.Core.Models;

public class ToDoItem
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
    
    //по идее не совсем понимаю, зачем нужна сущность приоритета, если можно просто иметь интом сам уровень приоритета в ToDoItem
    [ForeignKey("PriorityId")]
    public Priority? Priority { get; set; }
    public int? PriorityId { get; set; }
    
    [ForeignKey("UserId")]
    public User? User { get; set; }
    public Guid? UserId { get; set; }
}