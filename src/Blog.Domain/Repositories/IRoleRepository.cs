using Blog.Domain.Entities;
using Blog.Kernel.Domain.Data;

namespace Blog.Domain.Repositories;

public interface IRoleRepository : IRepository<Role>
{
    Task<bool> AddUserInRoleAsync(Role role, User user);
}