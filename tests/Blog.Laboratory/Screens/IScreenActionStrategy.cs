namespace Blog.Laboratory.Screens;

public interface IScreenActionStrategy : IDisposable
{
    Task<bool> BuildScreenAsync();
}