using System.ComponentModel.DataAnnotations;
using MediatR;

namespace TodoApp.Business.Services.Todo;

public class TodoCreateCommand : IRequest<bool>
{
    [Required(ErrorMessage = "{0} is required")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(255, ErrorMessage = "{0} must be between {2} and {1} characters", MinimumLength = 3)]
    public required string Title { get; set; }

    public bool IsCompleted { get; set; }

    public Guid CategoryId { get; set; }
}
