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
    }
}