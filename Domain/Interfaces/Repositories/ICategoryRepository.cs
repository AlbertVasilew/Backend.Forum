using Domain.Repositories;

namespace Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        new Task<List<Category>> GetAll();
        Task Delete(int id);
        Task Update(int id, string name, string color);
    }
}