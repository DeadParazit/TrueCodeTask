using TrueCodeUlanYeskendirovTask.Core.Models;

namespace TrueCodeUlanYeskendirovTask.Repository.Repositories;

public class ToDoItemRepository(TrueCodeDbContext context)
    : BaseRepository<ToDoItem, Guid>(context), IToDoItemRepository;