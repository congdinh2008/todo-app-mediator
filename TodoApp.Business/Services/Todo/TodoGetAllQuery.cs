using MediatR;
using TodoApp.Business.ViewModels.Todo;

namespace TodoApp.Business.Services.Todo;

public class TodoGetAllQuery : IRequest<IEnumerable<TodoViewModel>>
{

}
