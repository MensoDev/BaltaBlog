using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.DataAccess.Repositories;

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    private readonly SqlConnection _connection;

    private const string AddUserInRoleScript =
        "INSERT INTO [Blog].[dbo].[UserRole] ([UserId], [RoleId]) VALUES (@UserId,@RoleId)";

    public RoleRepository(SqlConnection connection) : base(connection)
    => _connection = connection;
    
    public async Task<bool> AddUserInRoleAsync(Role role, User user)
    {
        var rows = await _connection.ExecuteAsync(
                AddUserInRoleScript, 
                new
                {
                    UserId = user.Id, 
                    RoleId = role.Id
                });

        return rows > 0;
    }
}