using User.Domain.Common;

namespace User.Applicaton.Intefaces.Repositories;

public interface IGenericRepository<T> where T : BaseEntity 
{
    Task<List<T>> GetAll(int pageSize = 10, int pageNumber = 1);
    Task<T?> GetById(Guid id);
    Task<T> Add(T entity);
    Task<Guid> Delete(Guid id);
    Task<bool> ExistById(Guid id);
}