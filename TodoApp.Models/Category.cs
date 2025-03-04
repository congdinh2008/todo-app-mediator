using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models;

public class Category: BaseEntity
{
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    
    [StringLength(255)]
    public string? Description { get; set; }
    
    public virtual Collection<Todo> Todos { get; set; } = [];
}
