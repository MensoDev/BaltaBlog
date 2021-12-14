using Blog.Kernel.Domain.Objects;

namespace Blog.Domain.Entities;

[Table("[Tag]")]
public class Tag : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    
    [Write(false)]
    public List<Post> Posts { get; set; }
}