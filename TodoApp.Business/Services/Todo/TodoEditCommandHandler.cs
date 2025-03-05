using MediatR;
using TodoApp.UnitOfWork;

namespace TodoApp.Business.Services.Todo;

public class TodoEditCommandHandler :
    IRequestHandler<TodoEditCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public TodoEditCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        TodoEditCommand request,
        CancellationToken cancellationToken)
    {
        // Check if Todo existed
        var entity = await _unitOfWork.TodoRepository.GetByIdAsync(request.Id) ??
            throw new KeyNotFoundException("Todo not found");

        // Check if Category existed
        var existingCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId) ??
            throw new KeyNotFoundException("Category not found");

        entity.Title = request.Title;
        entity.IsCompleted = request.IsCompleted;
        entity.CategoryId = existingCategory.Id;

        return await _unitOfWork.SaveChangesAsync() > 0;
    }
}
