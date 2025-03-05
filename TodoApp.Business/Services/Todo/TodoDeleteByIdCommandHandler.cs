using MediatR;
using TodoApp.UnitOfWork;

namespace TodoApp.Business.Services.Todo;

public class TodoDeleteByIdCommandHandler :
    IRequestHandler<TodoDeleteByIdCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public TodoDeleteByIdCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        TodoDeleteByIdCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.TodoRepository.GetByIdAsync(request.Id) ??
            throw new KeyNotFoundException("Todo not found");

        _unitOfWork.TodoRepository.Delete(entity);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }
}
