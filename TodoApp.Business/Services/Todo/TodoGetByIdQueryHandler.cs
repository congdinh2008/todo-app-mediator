using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Business.ViewModels.Todo;
using TodoApp.UnitOfWork;

namespace TodoApp.Business.Services.Todo;

public class TodoGetByIdQueryHandler :
    IRequestHandler<TodoGetByIdQuery, TodoViewModel>
{
    private readonly IUnitOfWork _unitOfWork;

    public TodoGetByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TodoViewModel> Handle(
        TodoGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.TodoRepository.GetQuery()
            .Include(t => t.Category)
            .FirstOrDefaultAsync(t => t.Id == request.Id) ??
             throw new KeyNotFoundException("Todo not found");

        return new TodoViewModel
        {
            Id = entity.Id,
            Title = entity.Title,
            IsCompleted = entity.IsCompleted,
            CategoryId = entity.CategoryId,
            Category = new ViewModels.Category.CategoryViewModel
            {
                Id = entity.Category!.Id,
                Name = entity.Category!.Name,
            }
        };
    }
}
