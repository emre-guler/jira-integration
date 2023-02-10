using Microsoft.EntityFrameworkCore;
using User.Applicaton.Exceptions;
using User.Applicaton.Intefaces.Repositories;
using User.Domain.Common;
using User.Persistence.Context;

namespace User.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly DatabaseContext _dbContext;
    private readonly DbSet<T> _entityContext;
    public GenericRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
        _entityContext = _dbContext.Set<T>();
    }

    public async Task<T> Add(T entity)
    {
        await _entityContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<Guid> Delete(Guid id)
    {
        T? entity = await this.GetById(id);
        if (entity is null)
            throw new UserException(CustomErrors.UserNotFound);
        entity.DeletedAt = DateTime.UtcNow;

        return entity.Id;
    }

    public async Task<bool> ExistById(Guid id)
    {
        return await _entityContext
            .Where(x => x.Id == id && !x.DeletedAt.HasValue)
            .AnyAsync();
    }

    public async Task<List<T>> GetAll(int pageSize = 10, int pageNumber = 1)
    {
        return await _entityContext
            .Where(x => !x.DeletedAt.HasValue)
            .Skip(pageSize * (pageNumber - 1)).Take(pageSize)
            .ToListAsync();
    }

    public async Task<T?> GetById(Guid id)
    {
        return await _entityContext
            .Where(x => x.Id == id && !x.DeletedAt.HasValue)
            .FirstOrDefaultAsync();
    }
}
