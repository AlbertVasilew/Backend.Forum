using Domain.Repositories;

namespace Domain.Interfaces.Repositories
{
    public interface ITaskItemRepository : IBaseRepository<TaskItem>
    {
        Task<List<TaskItem>> GetAllByCategory(int categoryId);
        Task<List<TaskItem>> GetOverdue();
        Task<int> GetOverdueCount();
        Task<List<TaskItem>> GetUpcoming();
        Task<int> GetUpcomingCount();
        Task<List<TaskItem>> GetUpcomingToday();
        Task<int> GetUpcomingTodayCount();
        Task<List<TaskItem>> GetCompleted();
        Task<int> GetCompletedCount();
        Task Complete(int id);
        Task Delete(int id);
    }
}