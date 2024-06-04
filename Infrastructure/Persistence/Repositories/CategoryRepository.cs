using Domain;
using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class CategoryRepository(ApplicationDbContext context) : BaseRepository<Category>(context), ICategoryRepository
    {
        public override async Task<List<Category>> GetAll()
        {
            return await context.Categories.Include(x => x.Tasks).ToListAsync();
        }

        public async Task Delete(int id)
            => await context.Categories.Where(x => x.Id == id).ExecuteDeleteAsync();

        public async Task Update(int id, string name, string color)
        {
            await context.Categories
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(x => x.SetProperty(p => p.Name, name).SetProperty(p => p.Color, color));
        }
    }
}