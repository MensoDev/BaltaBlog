using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Domain.Entities;

[Table("[Category]")]
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}