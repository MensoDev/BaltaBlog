using Microsoft.Data.SqlClient;

namespace Blog.DataAccess.Factories;

public interface IConnectionFactory
{
    SqlConnection CreateConnection();
    SqlConnection CreateConnection(string connectionString);

}