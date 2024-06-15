using Domain;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class TaskItemRepository(ApplicationDbContext context) : BaseRepository<TaskItem>(context), ITaskItemRepository
    {
        public async Task<List<TaskItem>> GetAllByCategory(int categoryId)
            => await context.Tasks
                .AsNoTracking().Include(x => x.Category).Where(x => x.CategoryId == categoryId).ToListAsync();

        public async Task<List<TaskItem>> GetUpcoming(string timezone, string userId)
            => await GetUpcomingQuery(timezone, userId).ToListAsync();

        public async Task<int> GetUpcomingCount(string timezone, string userId)
            => await GetUpcomingQuery(timezone, userId).CountAsync();

        public async Task<List<TaskItem>> GetUpcomingToday(string timezone, string userId)
            => await GetUpcomingTodayQuery(timezone, userId).ToListAsync();

        public async Task<int> GetUpcomingTodayCount(string timezone, string userId)
            => await GetUpcomingTodayQuery(timezone, userId).CountAsync();

        public async Task<List<TaskItem>> GetOverdue(string timezone, string userId)
            => await GetOverdueQuery(timezone, userId).ToListAsync();

        public async Task<int> GetOverdueCount(string timezone, string userId)
            => await GetOverdueQuery(timezone, userId).CountAsync();

        public async Task<List<TaskItem>> GetCompleted(string userId)
            => await GetCompletedQuery(userId).ToListAsync();

        public async Task<int> GetCompletedCount(string userId)
            => await GetCompletedQuery(userId).CountAsync();

        public async Task Delete(int id)
            => await context.Tasks.Where(x => x.Id == id).ExecuteDeleteAsync();

        public async Task Update(int id, string name, DateTime deadline, int? categoryId)
            => await context.Tasks.Where(x => x.Id == id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Name, name)
                .SetProperty(x => x.Deadline, deadline)
                .SetProperty(x => x.CategoryId, categoryId));

        public async Task Complete(int id)
            => await context.Tasks.Where(x => x.Id == id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.CompletedOn, DateTime.UtcNow));

        private DateTime GetDateTimeByTimezone(string timezone)
            => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(timezone));

        private IQueryable<TaskItem> GetBaseQuery(string userId)
            => context.Tasks.AsNoTracking().Include(x => x.Category).Where(x => x.UserId == userId);

        private IQueryable<TaskItem> GetUpcomingQuery(string timezone, string userId)
            => GetBaseQuery(userId).Where(x => TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                x.Deadline, timezone).Date > GetDateTimeByTimezone(timezone).Date &&
                x.CompletedOn == null);

        private IQueryable<TaskItem> GetUpcomingTodayQuery(string timezone, string userId)
            => GetBaseQuery(userId).Where(x => TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                x.Deadline, timezone).Date == GetDateTimeByTimezone(timezone).Date &&
                x.CompletedOn == null);

        private IQueryable<TaskItem> GetOverdueQuery(string timezone, string userId)
            => GetBaseQuery(userId).Where(x => TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                x.Deadline, timezone).Date < GetDateTimeByTimezone(timezone).Date &&
                x.CompletedOn == null);

        private IQueryable<TaskItem> GetCompletedQuery(string userId)
            => GetBaseQuery(userId).Where(x => x.CompletedOn != null);
    }
}