using MediatR;
using TodoApp.UnitOfWork;

namespace TodoApp.Business.Services.Category;

public class CategoryEditCommandHandler :
    IRequestHandler<CategoryEditCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryEditCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        CategoryEditCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id) ??
            throw new KeyNotFoundException("Category not found");

        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.IsActive = request.IsActive;

        return await _unitOfWork.SaveChangesAsync() > 0;
    }
}
