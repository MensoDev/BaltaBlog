namespace Blog.Kernel.Domain.Data;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);

    Task<bool> RegisterAsync(T entity);

    Task<bool> RemoveAsync(T entity);
    Task<bool> UpdateAsync(T entity);
}