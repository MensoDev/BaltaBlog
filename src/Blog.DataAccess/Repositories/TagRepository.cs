using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.DataAccess.Repositories;

public class TagRepository : RepositoryBase<Tag>, ITagRepository
{
    public TagRepository(SqlConnection connection) : base(connection)
    {
    }
}