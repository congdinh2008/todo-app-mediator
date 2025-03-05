using MediatR;
using TodoApp.UnitOfWork;

namespace TodoApp.Business.Services.Todo;

public class TodoCreateCommandHandler :
    IRequestHandler<TodoCreateCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public TodoCreateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        TodoCreateCommand request,
        CancellationToken cancellationToken)
    {
        // Check if Category existed
        var existingCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId) ??
            throw new KeyNotFoundException("Category not found");

        var entity = new Models.Todo
        {
            Id = request.Id,
            Title = request.Title,
            IsCompleted = request.IsCompleted,
            CategoryId = existingCategory.Id,
        };

        _unitOfWork.TodoRepository.Add(entity);

        return await _unitOfWork.SaveChangesAsync() > 0;
    }
}
