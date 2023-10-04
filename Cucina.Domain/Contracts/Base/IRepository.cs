using Cucina.Domain.Entities.Base;
using System.Linq.Expressions;

namespace Cucina.Domain
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>
    {
        #region Asynchronous

        Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<TEntity>> GetAllByPredicateAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IQueryable<TEntity>> GetAllAsQueryableAsync(CancellationToken cancellationToken = default);
        Task<IQueryable<TEntity>> GetAllByPredicateAsQueryableAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<TEntity?> GetByIdAsync(TPrimaryKey id, CancellationToken cancellationToken = default);
        Task<TEntity?> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<bool> IsExistEntityByPredicateAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<bool> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TPrimaryKey> CreateAndGetIdAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TPrimaryKey> UpdateAndGetIdAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(TPrimaryKey id, CancellationToken cancellationToken = default);

        #endregion

        #region Synchronous

        IReadOnlyList<TEntity> GetAll(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<TEntity>> GetAllByPredicate(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        IQueryable<TEntity> GetAllAsQueryable(CancellationToken cancellationToken = default);
        IQueryable<TEntity> GetAllByPredicateAsQueryable(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        TEntity? GetById(TPrimaryKey id, CancellationToken cancellationToken = default);
        TEntity? GetByPredicate(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        bool IsExistEntityByPredicate(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        bool Create(TEntity entity, CancellationToken cancellationToken = default);
        bool Update(TEntity entity, CancellationToken cancellationToken = default);
        TPrimaryKey CreateAndGetId(TEntity entity, CancellationToken cancellationToken = default);
        TPrimaryKey UpdateAndGetId(TEntity entity, CancellationToken cancellationToken = default);
        bool Delete(TEntity entity, CancellationToken cancellationToken = default);
        bool Delete(TPrimaryKey id, CancellationToken cancellationToken = default);

        #endregion
    }
}
