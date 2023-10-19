using Cucina.Domain.Entities.Base;

namespace Cucina.Domain;

public interface IUnitOfWork : IAsyncDisposable, IDisposable
{
    IRepository<TEntity, TPrimaryKey>? GetRepository<TEntity, TPrimaryKey>() where TEntity : BaseEntity<TPrimaryKey>;
    Task SaveChangesAsync();
    void SaveChanges();
}