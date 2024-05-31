using Domain.Repositories;

namespace Domain.Interfaces.Repositories
{
    public interface ITaskItemRepository : IBaseRepository<TaskItem>
    {
        Task<List<TaskItem>> GetAllByCategory(int categoryId);
        Task<List<TaskItem>> GetUpcoming();
    }
}