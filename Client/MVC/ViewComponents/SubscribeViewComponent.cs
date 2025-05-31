using Microsoft.AspNetCore.Mvc;

namespace MVC.ViewComponents;

public class SubscribeViewComponent:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
