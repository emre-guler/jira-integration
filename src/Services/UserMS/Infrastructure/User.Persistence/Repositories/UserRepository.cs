using Microsoft.EntityFrameworkCore;
using User.Applicaton.Intefaces.Repositories;
using User.Persistence.Context;

namespace User.Persistence.Repositories;

public class UserRepository : GenericRepository<Domain.Entities.User>, IUserRepository
{
    private readonly DatabaseContext _dbContext;
    public UserRepository(DatabaseContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> IsMailExist(string mailAddress)
    {
        return await _dbContext.Users
            .Where(x => x.EmailAddres == mailAddress && !x.DeletedAt.HasValue)
            .AnyAsync();
    }
}
