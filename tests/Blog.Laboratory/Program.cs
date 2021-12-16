using Blog.Infrastructure.IoC;

namespace Blog.Laboratory;

public static class Program
{
    private const string ConnectionString = "Server=localhost,1433;Database=Blog;TrustServerCertificate=True;User ID=sa;Password=7PowerH@@K";
    
    public static async Task Main(string[] args)
    {
        DependencyInjection.Services.AddBlogServices(ConnectionString);
        await ScreenFrameFactory.CreateMainScreenFrame().LoadScreen();
    }
}