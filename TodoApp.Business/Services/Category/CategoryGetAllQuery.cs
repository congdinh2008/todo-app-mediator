using MediatR;
using TodoApp.Business.ViewModels.Category;
using TodoApp.UnitOfWork;

namespace TodoApp.Business.Services.Category;

public class CategoryGetAllQuery: IRequest<IEnumerable<CategoryViewModel>>
{

}

public class CategoryGetAllQueryHandler : 
    IRequestHandler<CategoryGetAllQuery, IEnumerable<CategoryViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryGetAllQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CategoryViewModel>> Handle(
        CategoryGetAllQuery request, CancellationToken cancellationToken)
    {
        var categories = await _unitOfWork.CategoryRepository.GetAllAsync();

        return categories.Select(x => new CategoryViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            IsActive = x.IsActive
        });
    }
}
