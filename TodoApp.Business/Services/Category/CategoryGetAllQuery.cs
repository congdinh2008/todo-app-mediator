using MediatR;
using TodoApp.Business.ViewModels.Category;

namespace TodoApp.Business.Services.Category;

public class CategoryGetAllQuery : IRequest<IEnumerable<CategoryViewModel>>
{

}
