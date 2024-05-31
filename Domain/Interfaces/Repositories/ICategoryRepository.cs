using Domain.Repositories;

namespace Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        new Task<List<Category>> GetAll();
    }
}