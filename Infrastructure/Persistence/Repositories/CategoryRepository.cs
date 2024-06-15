using Domain;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class CategoryRepository(ApplicationDbContext context) : BaseRepository<Category>(context), ICategoryRepository
    {
        public async Task<List<Category>> GetAll(string userId)
            => await context.Categories.Include(x => x.Tasks).Where(x => x.UserId == userId).ToListAsync();

        public async Task Delete(int id)
            => await context.Categories.Where(x => x.Id == id).ExecuteDeleteAsync();

        public async Task Update(int id, string name, string color) =>
            await context.Categories.Where(x => x.Id == id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Name, name)
                .SetProperty(x => x.Color, color));
    }
}