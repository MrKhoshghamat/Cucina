namespace Cucina.Application.Interfaces.Base;

public interface IRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync(Guid? id);
    Task<T> GetByIdAsync(Guid id);
    Task<string> AddAsync(T entity);
    Task<string> UpdateAsync(T entity);
    Task<string> DeleteAsync(Guid id);
}