using Microsoft.Data.SqlClient;

namespace Blog.DataAccess.Factories;

public class ConnectionFactory : IConnectionFactory
{

    private readonly string _connectionString;

    public ConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }

    public SqlConnection CreateConnection(string connectionString)
    {
        return new SqlConnection(connectionString);
    }
}