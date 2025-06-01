using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;

public class DashboardController : Controller
{
    private readonly IServiceManager _serviceManager;

    public DashboardController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public IActionResult Index()
    {
        return View();
    }
}
