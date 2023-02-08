using User.Domain.Common;

namespace User.Applicaton.Intefaces.Repositories;

public interface IGenericRepository<T> where T : BaseEntity 
{
    Task<List<T>> GetAll();
    Task<T> GetById(Guid id);
    Task<T> Add(T entity);
    Task<bool> Delete(Guid id);
}