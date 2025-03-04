using MediatR;

namespace TodoApp.Business.Services.Category;

public class CategoryDeleteByIdCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
