using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext context;

        public BaseRepository(DbContext context)
        {
            this.context = context;
        }

        public async Task Create(T entity)
        {
            await context.AddAsync(entity);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }
    }
}