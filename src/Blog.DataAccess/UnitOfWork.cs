using Blog.DataAccess.Factories;
using Blog.DataAccess.Repositories;
using Blog.Domain;
using Blog.Domain.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly SqlConnection _connection;

    public UnitOfWork(IConnectionFactory factory)
    {
        _connection = factory.CreateConnection();
        UserRepository = new UserRepository(_connection);
        RoleRepository = new RoleRepository(_connection);
        CategoryRepository = new CategoryRepository(_connection);
        TagRepository = new TagRepository(_connection);
    }

    public IUserRepository UserRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public ITagRepository TagRepository { get; }

    public void Dispose()
    {
        _connection.Dispose();
        GC.SuppressFinalize(this);
    }
}