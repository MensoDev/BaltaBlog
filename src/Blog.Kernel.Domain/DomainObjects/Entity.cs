using System.ComponentModel.DataAnnotations;

namespace Blog.Kernel.Domain.DomainObjects;

public abstract class Entity
{
    [Key]
    public int Id { get; set; }
}