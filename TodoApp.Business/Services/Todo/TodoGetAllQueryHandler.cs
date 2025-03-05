using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Business.ViewModels.Todo;
using TodoApp.UnitOfWork;

namespace TodoApp.Business.Services.Todo;

public class TodoGetAllQueryHandler :
    IRequestHandler<TodoGetAllQuery, IEnumerable<TodoViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public TodoGetAllQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TodoViewModel>> Handle(
        TodoGetAllQuery request, CancellationToken cancellationToken)
    {
        var todos = await _unitOfWork.TodoRepository.GetQuery().Include(x =>x.Category).ToListAsync();

        return todos.Select(x => new TodoViewModel
        {
            Id = x.Id,
            Title = x.Title,
            IsCompleted = x.IsCompleted,
            CategoryId = x.CategoryId,
            Category = new ViewModels.Category.CategoryViewModel{
                Id = x.Category!.Id,
                Name = x.Category.Name,
            }
        });
    }
}
