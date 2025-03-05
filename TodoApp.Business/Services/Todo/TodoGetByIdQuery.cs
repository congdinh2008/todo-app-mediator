using MediatR;
using TodoApp.Business.ViewModels.Todo;

namespace TodoApp.Business.Services.Todo;

public class TodoGetByIdQuery : IRequest<TodoViewModel>
{
    public Guid Id { get; set; }
}
