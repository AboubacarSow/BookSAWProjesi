using Contracts;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Threading.Tasks;

namespace MVC.Controllers;

public class DashboardController : Controller
{
    private readonly IServiceManager _serviceManager;

    public DashboardController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public async Task<IActionResult> Index()
    {
        var model = new DashboardViewModel();
        model.Categories=await _serviceManager.CategoryService.GetAllCategoriesAsync();
        model.TotalCategory=model.Categories.Count;
        model.FeaturedBook=(await _serviceManager.BookService.GetAllBooksAsync())
            .OrderByDescending(x=>x.Id).Take(4).ToList();
        model.TotalBook=(await _serviceManager.BookService.GetAllBooksAsync()).Count;
        return View(model);
    }
}
