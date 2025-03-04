using MediatR;
using TodoApp.UnitOfWork;

namespace TodoApp.Business.Services.Category;

public class CategoryDeleteByIdCommandHandler :
    IRequestHandler<CategoryDeleteByIdCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryDeleteByIdCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        CategoryDeleteByIdCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id) ??
            throw new KeyNotFoundException("Category not found");

        _unitOfWork.CategoryRepository.Delete(entity);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }
}
