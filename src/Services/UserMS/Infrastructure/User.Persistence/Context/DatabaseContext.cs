using Microsoft.EntityFrameworkCore;

namespace User.Persistence.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    public DbSet<Domain.Entities.User> Users { get; set; }
}
