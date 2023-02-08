using User.Applicaton.Intefaces.Repositories;
using User.Persistence.Context;

namespace User.Persistence.Repositories;

public class UserRepository : GenericRepository<Domain.Entities.User>, IUserRepository
{
    public UserRepository(DatabaseContext dbContext) : base(dbContext)
    {

    }
}
