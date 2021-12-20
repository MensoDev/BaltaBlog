using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.DataAccess.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    
    private readonly SqlConnection _connection;

    public UserRepository(SqlConnection connection) : base(connection)
        => _connection = connection;

    public async Task<IEnumerable<User>> GetAllWithRolesAsync()
    {
        const string query = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

        var users = new List<User>();
        await _connection.QueryAsync<User, Role, User>(
            query,
            (user, role) =>
            {
                var usr = users.FirstOrDefault(x => x.Id == user.Id);
                if (usr == null)
                {
                    usr = user;
                    if(role != null)
                        usr.Roles.Add(role);
                    users.Add(usr);
                }
                else
                    usr.Roles.Add(role);

                return user;
            }, splitOn: "Id");
        
        return users;
    }
}