using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MVC.ViewComponents
{
    public class BestSellingViewComponent: ViewComponent
    {
        private IServiceManager serviceManager;
        public BestSellingViewComponent(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var books = await serviceManager.BookService.GetAllBooksAsync();
            var count = books.Count;
            var bookIds = (from book in books
                           select new { book.Id });
            var dictionaire = new Dictionary<int, int>();
            int index = 0;
            foreach (var value in bookIds)
            {
                index++;
                dictionaire.Add(index, value.Id);
            }
            var rdn = new Random().Next(1, count);
            var randomId = dictionaire[rdn];
            var best= books.Find(b => b.Id == randomId);
            return View(best);
        }
    }
}
