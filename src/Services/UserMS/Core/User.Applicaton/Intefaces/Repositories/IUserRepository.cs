namespace User.Applicaton.Intefaces.Repositories;
public interface IUserRepository : IGenericRepository<Domain.Entities.User>
{
    Task<bool> IsMailExist(string mailAddress);
}