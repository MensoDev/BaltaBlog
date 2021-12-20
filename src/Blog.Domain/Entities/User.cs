using Blog.Kernel.Domain.Objects;

namespace Blog.Domain.Entities;

[Table("[User]")]
public class User : Entity
{

    public User()
    {
        Roles = new List<Role>();
    }
    
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Bio { get; set; }
    public string Image { get; set; }
    public string Slug { get; set; }

    [Write(false)]
    public List<Role> Roles { get; set; }
}