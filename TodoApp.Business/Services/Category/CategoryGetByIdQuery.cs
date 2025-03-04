using MediatR;
using TodoApp.Business.ViewModels.Category;
using TodoApp.UnitOfWork;

namespace TodoApp.Business.Services.Category;

public class CategoryGetByIdQuery : IRequest<CategoryViewModel>
{
    public Guid Id { get; set; }
}

public class CategoryGetByIdQueryHandler :
    IRequestHandler<CategoryGetByIdQuery, CategoryViewModel>
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryGetByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CategoryViewModel> Handle(
        CategoryGetByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id) ??
             throw new KeyNotFoundException("Category not found");
             
        return new CategoryViewModel
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            IsActive = category.IsActive
        };
    }
}
