using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Business.Services.Category;

namespace TodoApp.MVC.Controllers;

public class CategoryController : Controller
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ActionResult> Index()
    {
        var query = new CategoryGetAllQuery();
        var categories = await _mediator.Send(query);
        return View(categories);
    }

    public async Task<ActionResult> Edit(Guid id)
    {
        var query = new CategoryGetByIdQuery(){
            Id = id
        };
        var category = await _mediator.Send(query);
        return View(category);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(CategoryEditCommand request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }
        
        var result = await _mediator.Send(request);

        if (result)
        {
            return RedirectToAction("Index");
        }

        return BadRequest();
    }

    [HttpPost]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new CategoryDeleteByIdCommand()
        {
            Id = id
        };
        var result = await _mediator.Send(command);

        if (result)
        {
            return RedirectToAction("Index");
        }

        return BadRequest();
    }
}
