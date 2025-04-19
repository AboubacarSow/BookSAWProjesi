using Services.Contracts;

namespace Services.Models
{
    public class ServiceManager : IServiceManager
    {
        private readonly ICategoryService _categoryService;
        private readonly IBookService _bookService;
        public ServiceManager(ICategoryService categoryService, IBookService bookService)
        {
            _categoryService = categoryService;
            _bookService = bookService;
        }
        public ICategoryService CategoryService => _categoryService;

        public IBookService BookService => _bookService;
    }
}
