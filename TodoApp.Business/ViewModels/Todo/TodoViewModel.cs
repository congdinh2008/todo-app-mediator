using System;
using System.ComponentModel.DataAnnotations;
using TodoApp.Business.ViewModels.Category;

namespace TodoApp.Business.ViewModels.Todo;

public class TodoViewModel
{
    [Required(ErrorMessage = "Id is required")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(255, ErrorMessage = "{0} must be between {2} and {1} characters", MinimumLength = 3)]
    public required string Title { get; set; }

    public bool IsCompleted { get; set; }

    public Guid CategoryId { get; set; }

    public CategoryViewModel? Category { get; set; }
}
