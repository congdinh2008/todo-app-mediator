using System;

namespace TodoApp.Business.ViewModels.Category;

public class CategoryViewModel
{
    public Guid Id { get; set; }

    public required string Name { get; set; }
    
    public string? Description { get; set; }

    public bool IsActive { get; set; }
}
