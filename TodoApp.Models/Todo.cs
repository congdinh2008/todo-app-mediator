using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models;

public class Todo: BaseEntity
{
    [Required]
    [StringLength(255)]
    public required string Title { get; set; }

    public bool IsCompleted { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public virtual Category? Category { get; set; }
}
