using System.ComponentModel.DataAnnotations;

namespace Blog.Kernel.Domain.Objects;

public abstract class Entity
{
    [Key]
    public int Id { get; set; }
}