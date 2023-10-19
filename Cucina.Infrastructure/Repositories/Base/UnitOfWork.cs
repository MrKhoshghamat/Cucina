using Cucina.Domain;
using Cucina.Domain.Entities.Base;
using Cucina.Persistence.Context;

namespace Cucina.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    #region Private Members

    private readonly CucinaDbContext _context;
    private readonly Dictionary<Type, object?> _repositories;

    #endregion

    #region Constructor

    public UnitOfWork(CucinaDbContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object?>();
    }

    #endregion

    #region Public Methods

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IRepository<TEntity, TPrimaryKey>? GetRepository<TEntity, TPrimaryKey>()
        where TEntity : BaseEntity<TPrimaryKey>
    {
        if (_repositories.TryGetValue(typeof(TEntity), out var value)) return (IRepository<TEntity, TPrimaryKey>)value!;

        var repository = new Repository<TEntity, TPrimaryKey>(_context);
        _repositories.Add(typeof(TEntity), repository);
        return repository;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    #endregion
}