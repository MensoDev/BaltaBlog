using Blog.Kernel.Domain.DomainObjects;
using Dapper.Contrib.Extensions;

namespace Blog.Domain.Entities;

[System.ComponentModel.DataAnnotations.Schema.Table("[Tag]")]
public class Tag : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    
    [Write(false)]
    public List<Post> Posts { get; set; }
}