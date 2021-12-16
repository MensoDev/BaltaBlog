using Blog.Domain.Repositories;

namespace Blog.Domain;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IRoleRepository RoleRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    
    ITagRepository TagRepository { get; }
}