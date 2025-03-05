using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodoApp.Business.Services.Category;
using TodoApp.Business.Services.Todo;
using TodoApp.Business.ViewModels.Todo;

namespace TodoApp.MVC.Controllers;

public class TodoController : Controller
{
    private readonly IMediator _mediator;

    public TodoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<ActionResult> Index()
    {
        var query = new TodoGetAllQuery();
        var categories = await _mediator.Send(query);
        return View(categories);
    }

    public async Task<ActionResult> Create()
    {
        var TodoViewModel = new TodoViewModel()
        {
            Title = ""
        };
        var query = new CategoryGetAllQuery();
        var categories = await _mediator.Send(query);
        ViewBag.Categories = categories.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        });
        return View(TodoViewModel);
    }

    [HttpPost]
    public async Task<ActionResult> Create(TodoViewModel todoViewModel)
    {
        // Validate model
        if (!ModelState.IsValid)
        {
            return View(todoViewModel);
        }

        var command = new TodoCreateCommand
        {
            Id = Guid.NewGuid(),
            Title = todoViewModel.Title,
            IsCompleted = todoViewModel.IsCompleted,
            CategoryId = todoViewModel.CategoryId
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
        var query = new TodoGetByIdQuery()
        {
            Id = id
        };
        var todo = await _mediator.Send(query);

        var queryCategory = new CategoryGetAllQuery();
        var categories = await _mediator.Send(queryCategory);
        ViewData["Categories"] = categories.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        });

        ViewBag.Categories = categories.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        });

        return View(todo);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(TodoViewModel todoViewModel)
    {
        // Validate model
        if (!ModelState.IsValid)
        {
            var queryCategory = new CategoryGetAllQuery();
            var categories = await _mediator.Send(queryCategory);
            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });
            return View(todoViewModel);
        }

        var command = new TodoEditCommand
        {
            Id = todoViewModel.Id,
            Title = todoViewModel.Title,
            IsCompleted = todoViewModel.IsCompleted,
            CategoryId = todoViewModel.CategoryId
        };

        var result = await _mediator.Send(command);

        if (result)
        {
            TempData["success"] = "Edit Successful!";
            return RedirectToAction("Index");
        }

        return BadRequest();
    }

    [HttpPost]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new TodoDeleteByIdCommand()
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
