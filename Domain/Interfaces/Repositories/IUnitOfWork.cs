
namespace Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChanges();
    }
}