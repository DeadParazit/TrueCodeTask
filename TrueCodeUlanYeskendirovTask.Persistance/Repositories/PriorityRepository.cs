using TrueCodeUlanYeskendirovTask.Core.Models;

namespace TrueCodeUlanYeskendirovTask.Repository.Repositories;

public class PriorityRepository(TrueCodeDbContext context)
    : BaseRepository<Priority, int>(context), IPriorityRepository;