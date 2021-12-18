using Blog.Kernel.Domain.Data;
using Blog.Kernel.Domain.Objects;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.DataAccess.Repositories;

public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly SqlConnection _connection;

    protected RepositoryBase(SqlConnection connection)
    {
        _connection = connection;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        => await _connection.GetAllAsync<TEntity>();

    public virtual async Task<TEntity?> GetByIdAsync(int id)
        => await _connection.GetAsync<TEntity>(id);

    public virtual async Task<bool> RegisterAsync(TEntity entity)
        => await _connection.InsertAsync(entity) > 0;

    public virtual async Task<bool> RemoveAsync(TEntity entity)
        => await _connection.DeleteAsync(entity);

    public virtual async Task<bool> UpdateAsync(TEntity entity)
        => await _connection.UpdateAsync(entity);
}