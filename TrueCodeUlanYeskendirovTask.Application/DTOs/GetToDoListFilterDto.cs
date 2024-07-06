namespace TrueCodeUlanYeskendirovTask.Service.DTOs;

public class GetToDoListFilterDto
{
    /// <summary>
    /// Фильтр по статусу<br />
    /// null - без фильтра<br />
    /// true - выполнено<br />
    /// false - не выполнено
    /// </summary>
    public bool? IsCompleted { get; set; }
    
    /// <summary>
    /// Фильтр по приоритету<br />
    /// null - без фильтра<br />
    /// true - по возрастанию<br />
    /// false - по убыванию
    /// </summary>
    public bool? IsPriorityAscending { get; set; }
}