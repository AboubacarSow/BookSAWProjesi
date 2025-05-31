using Contracts;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.ViewComponents
{
    public class PopularViewComponent : ViewComponent
    {
        public IServiceManager _serviceManager;
        public PopularViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var books = await _serviceManager.BookService.GetAllBooksAsync();
            var categories = await _serviceManager.CategoryService.GetAllCategoriesAsync();
            var modelView = new PopularModelView();
            modelView.Books = books;
            modelView.Categories = categories;
            return View(modelView);
        }
    }
}
