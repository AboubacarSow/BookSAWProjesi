using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;
public class SubscriberController : Controller
{
    private readonly IServiceManager _serviceManager;

    public SubscriberController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    public async Task<IActionResult> Index()
    {
        var  subscribers=await _serviceManager.SubscriberService.GetAll();
        return View(subscribers);
    }
    public async Task<IActionResult> Delete(int id)
    {
        var result=await _serviceManager.SubscriberService.Delete(id);
        return result ? Json(new {success=true}) : Json(new {success=false});
    }
}
