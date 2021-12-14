using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.DataAccess.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    
    private readonly SqlConnection _connection;

    public UserRepository(SqlConnection connection) : base(connection)
        => _connection = connection;

}