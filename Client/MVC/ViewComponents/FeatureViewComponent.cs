using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MVC.ViewComponents
{
    public class FeatureViewComponent:ViewComponent
    {
        private IServiceManager _manager;
        public FeatureViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var books = (await _manager.BookService.GetAllBooksAsync())
                .Take(4)
                .ToList();
            return View(books);
        }
    }
}
