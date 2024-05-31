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
        {
            return await context.Tasks
                .AsNoTracking()
                .Include(x => x.Categories)
                .Where(x => x.CreatedOn < DateTime.UtcNow)
                .ToListAsync();
        }
    }
}