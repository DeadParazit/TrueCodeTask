using TrueCodeUlanYeskendirovTask.Core.Models;

namespace TrueCodeUlanYeskendirovTask.Repository.Repositories;

public class UserRepository(TrueCodeDbContext context)
    : BaseRepository<User, Guid>(context), IUserRepository;