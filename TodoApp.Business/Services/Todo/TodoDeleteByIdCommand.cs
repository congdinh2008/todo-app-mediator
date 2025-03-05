using MediatR;

namespace TodoApp.Business.Services.Todo;

public class TodoDeleteByIdCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
