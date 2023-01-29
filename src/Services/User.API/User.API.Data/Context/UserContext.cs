using Microsoft.EntityFrameworkCore;

namespace User.API.Data.Context;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {

    }
    
    public virtual DbSet<Entities.User> Users { get; set; }
}