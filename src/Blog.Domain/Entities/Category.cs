using System.ComponentModel.DataAnnotations.Schema;
using Blog.Kernel.Domain.DomainObjects;

namespace Blog.Domain.Entities;

[Table("[Category]")]
public class Category : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}