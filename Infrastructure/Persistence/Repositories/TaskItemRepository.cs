using Domain;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Persistence.Repositories
{
    public class TaskItemRepository(ApplicationDbContext context) : BaseRepository<TaskItem>(context), ITaskItemRepository
    {
        public async Task<List<TaskItem>> GetAllByCategory(int categoryId)
        {
            return await context.Tasks
                .AsNoTracking()
                .Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetUpcoming(string timezone)
        {
            return await GetBaseQuery()
                .Where(x => TimeZoneInfo.ConvertTimeBySystemTimeZoneId(x.Deadline, timezone).Date > GetDateTimeByTimezone(timezone).Date)
                .ToListAsync();
        }

        public async Task<int> GetUpcomingCount(string timezone)
        {
            return await context.Tasks.CountAsync(x => TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                x.Deadline, timezone).Date > GetDateTimeByTimezone(timezone).Date && x.CompletedOn == null);
        }

        public async Task<List<TaskItem>> GetUpcomingToday(string timezone)
        {
            return await GetBaseQuery().Where(x => TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                x.Deadline, timezone).Date == GetDateTimeByTimezone(timezone).Date).ToListAsync();
        }
        public async Task<int> GetUpcomingTodayCount(string timezone)
            => await context.Tasks.CountAsync(x => TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                x.Deadline, timezone).Date == GetDateTimeByTimezone(timezone).Date && x.CompletedOn == null);

        public async Task<List<TaskItem>> GetOverdue(string timezone)
            => await GetBaseQuery().Where(x => TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                x.Deadline, timezone) < GetDateTimeByTimezone(timezone)).ToListAsync();

        public async Task<int> GetOverdueCount(string timezone)
            => await context.Tasks.CountAsync(x => TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
                x.Deadline, timezone) < GetDateTimeByTimezone(timezone) && x.CompletedOn == null);

        public async Task<List<TaskItem>> GetCompleted()
            => await context.Tasks.AsNoTracking().Include(x => x.Category).Where(x => x.CompletedOn != null).ToListAsync();

        public async Task<int> GetCompletedCount()
            => await context.Tasks.CountAsync(x => x.CompletedOn != null);

        public async Task Complete(int id)
            => await context.Tasks
                .Where(x => x.Id == id).ExecuteUpdateAsync(x => x.SetProperty(p => p.CompletedOn, DateTime.UtcNow));

        public async Task Delete(int id)
            => await context.Tasks.Where(x => x.Id == id).ExecuteDeleteAsync();

        public async Task Update(int id, string name, DateTime deadline, int? categoryId)
        {
            await context.Tasks.Where(x => x.Id == id).ExecuteUpdateAsync(x => x
                .SetProperty(p => p.Name, name)
                .SetProperty(p => p.Deadline, deadline)
                .SetProperty(p => p.CategoryId, categoryId));
        }

        private DateTime GetDateTimeByTimezone(string timezone)
            => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(timezone));

        private IQueryable<TaskItem> GetBaseQuery()
            => context.Tasks.AsNoTracking().Include(x => x.Category).Where(x => x.CompletedOn == null);

    }
}