using User.Applicaton.Intefaces.Repositories;
using User.Domain.Common;
using User.Persistence.Context;

namespace User.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly DatabaseContext _dbContext;
    public GenericRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> Add(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> Delete(Guid id)
    {
        T? entity = await this.GetById(id);
        if (entity is null)
            return false;

        entity.DeletedAt = DateTime.UtcNow;
        return true;
    }

    public Task<List<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}
