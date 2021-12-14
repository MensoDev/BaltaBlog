using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.DataAccess.Repositories;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{

    private readonly SqlConnection _connection;

    public CategoryRepository(SqlConnection connection) : base(connection)
    => _connection = connection;
    

    
}