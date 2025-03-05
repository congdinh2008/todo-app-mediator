using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Business.Services.Category;
using TodoApp.Business.ViewModels.Category;

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

    public ActionResult Create()
    {
        var categoryViewModel = new CategoryViewModel(){
            Name = ""
        };
        return View(categoryViewModel);
    }

    [HttpPost]
    public async Task<ActionResult> Create(CategoryViewModel categoryViewModel)
    {
        // Validate model
        if (!ModelState.IsValid)
        {
            return View(categoryViewModel);
        }

        var command = new CategoryCreateCommand {
            Id = Guid.NewGuid(),
            Name = categoryViewModel.Name,
            Description = categoryViewModel.Description,
            IsActive = categoryViewModel.IsActive,
        };
        
        var result = await _mediator.Send(command);

        if (result)
        {
            return RedirectToAction("Index");
        }

        return BadRequest();
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
    public async Task<ActionResult> Edit(CategoryViewModel categoryViewModel)
    {
        // Validate model
        if (!ModelState.IsValid)
        {
            return View(categoryViewModel);
        }

        var command = new CategoryEditCommand {
            Id = categoryViewModel.Id,
            Name = categoryViewModel.Name,
            Description = categoryViewModel.Description,
            IsActive = categoryViewModel.IsActive,
        };
        
        var result = await _mediator.Send(command);

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
