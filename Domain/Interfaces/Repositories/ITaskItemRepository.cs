using Domain.Repositories;

namespace Domain.Interfaces.Repositories
{
    public interface ITaskItemRepository : IBaseRepository<TaskItem>
    {
        Task Complete(int id);
        Task Delete(int id);
        Task Update(int id, string name, DateTime deadline, int? categoryId);
        Task<List<TaskItem>> GetAllByCategory(int categoryId);
        Task<List<TaskItem>> GetCompleted(string userId);
        Task<int> GetCompletedCount(string userId);
        Task<List<TaskItem>> GetOverdue(string timezone, string userId);
        Task<int> GetOverdueCount(string timezone, string userId);
        Task<List<TaskItem>> GetUpcoming(string timezone, string userId);
        Task<int> GetUpcomingCount(string timezone, string userId);
        Task<List<TaskItem>> GetUpcomingToday(string timezone, string userId);
        Task<int> GetUpcomingTodayCount(string timezone, string userId);
    }
}