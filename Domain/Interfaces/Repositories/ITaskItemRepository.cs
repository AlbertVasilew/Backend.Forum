using Domain.Repositories;

namespace Domain.Interfaces.Repositories
{
    public interface ITaskItemRepository : IBaseRepository<TaskItem>
    {
        Task Complete(int id);
        Task Delete(int id);
        Task Update(int id, string name, string description, DateTime deadline, int? categoryId);
        Task<List<TaskItem>> GetAllByCategory(int categoryId);
        Task<List<TaskItem>> GetCompleted();
        Task<int> GetCompletedCount();
        Task<List<TaskItem>> GetOverdue(string timezone);
        Task<int> GetOverdueCount(string timezone);
        Task<List<TaskItem>> GetUpcoming(string timezone);
        Task<int> GetUpcomingCount(string timezone);
        Task<List<TaskItem>> GetUpcomingToday(string timezone);
        Task<int> GetUpcomingTodayCount(string timezone);
    }
}