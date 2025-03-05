using MediatR;
using TodoApp.UnitOfWork;

namespace TodoApp.Business.Services.Category;

public class CategoryCreateCommandHandler :
    IRequestHandler<CategoryCreateCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryCreateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        CategoryCreateCommand request,
        CancellationToken cancellationToken)
    {
        var entity = new Models.Category(){
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            IsActive = request.IsActive,
        };
        _unitOfWork.CategoryRepository.Add(entity);

        return await _unitOfWork.SaveChangesAsync() > 0;
    }
}
