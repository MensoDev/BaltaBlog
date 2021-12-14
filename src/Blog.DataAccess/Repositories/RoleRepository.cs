using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.DataAccess.Repositories;

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    private readonly SqlConnection _connection;

    public RoleRepository(SqlConnection connection) : base(connection)
    => _connection = connection;
    
    
}