using Microsoft.Extensions.DependencyInjection;

namespace Blog.Laboratory;

public static class DependencyInjection
{
    public static IServiceCollection Services { get; set; } = new ServiceCollection();
    public static IServiceProvider Provider => Services.BuildServiceProvider();

}