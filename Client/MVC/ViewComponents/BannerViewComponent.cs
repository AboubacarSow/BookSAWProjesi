using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MVC.ViewComponents
{
    public class BannerViewComponent:ViewComponent
    {
        private IServiceManager _serviceManager;
        public BannerViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var books=await _serviceManager.BookService.GetBannerBookDtosAsync();
            return View(books);
        }
        
    }
}
