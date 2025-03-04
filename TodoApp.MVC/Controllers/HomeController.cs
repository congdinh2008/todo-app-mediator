using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoApp.MVC.Models;

namespace TodoApp.MVC.Controllers;

public class HomeController : Controller
{
    public HomeController()
    {
    }

    public async Task<IActionResult> Index()
    {
       
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
