using Blog.DataAccess;
using Blog.DataAccess.Factories;
using Blog.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure.IoC;

public static class ServiceCollectionBlogConfigure
{
    public static IServiceCollection AddBlogServices(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IConnectionFactory>(new ConnectionFactory(connectionString));
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}