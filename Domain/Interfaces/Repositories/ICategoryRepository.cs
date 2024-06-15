using Domain.Repositories;

namespace Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<List<Category>> GetAll(string userId);
        Task Delete(int id);
        Task Update(int id, string name, string color);
    }
}