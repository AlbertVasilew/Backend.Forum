
namespace Domain.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task Create(T entity);
    }
}