using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Business.ViewModels.Category;

public class CategoryViewModel
{
    [Required(ErrorMessage = "Id is required")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(255, ErrorMessage = "Name must be between {2} and {1} characters", MinimumLength = 3)]
    public required string Name { get; set; }

    [StringLength(255, ErrorMessage = "Description must be {1} characters")]
    public string? Description { get; set; }

    public bool IsActive { get; set; }
}
