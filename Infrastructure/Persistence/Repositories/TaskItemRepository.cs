using Domain;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class TaskItemRepository(ApplicationDbContext context) : BaseRepository<TaskItem>(context), ITaskItemRepository
    {
        public async Task<List<TaskItem>> GetAllByCategory(int categoryId)
        {
            return await context.Tasks
                .AsNoTracking()
                .Include(x => x.Categories)
                .Where(x => x.Categories.Any(y => y.Id == categoryId))
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetUpcoming()
            => await GetBaseUpcomingQuery().Where(x => x.Deadline.Date > DateTime.UtcNow.Date).ToListAsync();

        public async Task<int> GetUpcomingCount()
            => await context.Tasks.CountAsync(x => x.Deadline.Date > DateTime.UtcNow.Date && x.CompletedOn == null);

        public async Task<List<TaskItem>> GetUpcomingToday()
            => await GetBaseUpcomingQuery().Where(x => x.Deadline.Date == DateTime.UtcNow.Date).ToListAsync();

        public async Task<int> GetUpcomingTodayCount()
            => await context.Tasks.CountAsync(x => x.Deadline.Date == DateTime.UtcNow.Date && x.CompletedOn == null);

        public async Task<List<TaskItem>> GetOverdue()
            => await context.Tasks.AsNoTracking().Include(x => x.Categories).Where(x => x.Deadline.Date < DateTime.UtcNow.Date && x.CompletedOn == null).ToListAsync();

        public async Task<int> GetOverdueCount()
            => await context.Tasks.CountAsync(x => x.Deadline.Date < DateTime.UtcNow.Date && x.CompletedOn == null);

        public async Task<List<TaskItem>> GetCompleted()
            => await context.Tasks.AsNoTracking().Include(x => x.Categories).Where(x => x.CompletedOn != null).ToListAsync();

        public async Task<int> GetCompletedCount()
            => await context.Tasks.CountAsync(x => x.CompletedOn != null);

        public async Task Complete(int id)
            => await context.Tasks
                .Where(x => x.Id == id).ExecuteUpdateAsync(x => x.SetProperty(p => p.CompletedOn, DateTime.UtcNow));

        public async Task Delete(int id)
            => await context.Tasks.Where(x => x.Id == id).ExecuteDeleteAsync();

        private IQueryable<TaskItem> GetBaseUpcomingQuery()
            => context.Tasks.AsNoTracking().Include(x => x.Categories).Where(x => x.CompletedOn == null);
    }
}