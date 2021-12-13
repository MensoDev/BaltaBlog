// See https://aka.ms/new-console-template for more information

using Blog.Domain.Entities;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Laboratory;

public static class Program
{

    private const string ConnectionString = "Server=localhost,1433;Database=Blog;TrustServerCertificate=True;User ID=sa;Password=7PowerH@@K";
    
    public static void Main(string[] args)
    {
        ReadUsers();
    }

    private static void ReadUsers()
    {
        using var conn = new SqlConnection(ConnectionString);
        var users = conn.GetAll<User>();
        foreach (var user in users)
        {
            Console.WriteLine("User: {0} Email: {1}", user.Name, user.Email);
        }
    }
}