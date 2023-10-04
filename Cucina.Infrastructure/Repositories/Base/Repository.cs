using Cucina.Domain;
using Cucina.Domain.Entities.Base;
using Cucina.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cucina.Infrastructure
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>
    {
        #region Private Members

        private readonly CucinaDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        #endregion

        #region Constructor

        public Repository(CucinaDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        #endregion

        #region Public Methods

        public bool Create(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                _dbSet.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TPrimaryKey CreateAndGetId(TEntity entity, CancellationToken cancellationToken = default)
        {
            Create(entity, cancellationToken);
            _context.SaveChanges();
            return entity.Id;
        }

        public async Task<TPrimaryKey> CreateAndGetIdAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await CreateAsync(entity, cancellationToken);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                await _dbSet.AddAsync(entity, cancellationToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                entity.IsDeleted = true;
                Update(entity, cancellationToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(TPrimaryKey id, CancellationToken cancellationToken = default)
        {
            try
            {
                TEntity? entity = GetById(id, cancellationToken);
                Delete(entity, cancellationToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                entity.IsDeleted = true;
                await UpdateAsync(entity, cancellationToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(TPrimaryKey id, CancellationToken cancellationToken = default)
        {
            try
            {
                TEntity? entity = await GetByIdAsync(id, cancellationToken);
                await DeleteAsync(entity, cancellationToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IReadOnlyList<TEntity> GetAll(CancellationToken cancellationToken = default)
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IQueryable<TEntity> GetAllAsQueryable(CancellationToken cancellationToken = default)
        {
            return _dbSet.AsQueryable();
        }

        public Task<IQueryable<TEntity>> GetAllAsQueryableAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_dbSet.AsQueryable());
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<TEntity>> GetAllByPredicate(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
        }

        public IQueryable<TEntity> GetAllByPredicateAsQueryable(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dbSet.Where(predicate).AsQueryable();
        }

        public Task<IQueryable<TEntity>> GetAllByPredicateAsQueryableAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_dbSet.Where(predicate).AsQueryable());
        }

        public async Task<IReadOnlyList<TEntity>> GetAllByPredicateAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(predicate).AsNoTracking().ToListAsync(cancellationToken);
        }

        public TEntity? GetById(TPrimaryKey id, CancellationToken cancellationToken = default)
        {
            return _dbSet.Find(id, cancellationToken);
        }

        public async Task<TEntity?> GetByIdAsync(TPrimaryKey id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(id, cancellationToken);
        }

        public TEntity? GetByPredicate(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }

        public async Task<TEntity?> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync(cancellationToken);
        }

        public bool IsExistEntityByPredicate(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return _dbSet.Where(predicate).Any();
        }

        public async Task<bool> IsExistEntityByPredicateAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(predicate).AnyAsync(cancellationToken);
        }

        public bool Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TPrimaryKey UpdateAndGetId(TEntity entity, CancellationToken cancellationToken = default)
        {
            Update(entity, cancellationToken);
            _context.SaveChanges();
            return entity.Id;
        }

        public async Task<TPrimaryKey> UpdateAndGetIdAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await UpdateAsync(entity, cancellationToken);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
