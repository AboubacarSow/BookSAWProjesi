using Services.Contracts;

namespace Services.Models
{
    public class ServiceManager : IServiceManager
    {
        private readonly ICategoryService _categoryService;
        private readonly IBookService _bookService;
        private readonly ISubscriberService _subscriberService;
        public ServiceManager(ICategoryService categoryService, IBookService bookService, ISubscriberService subscriberService)
        {
            _categoryService = categoryService;
            _bookService = bookService;
            _subscriberService = subscriberService;
        }
        public ICategoryService CategoryService => _categoryService;
        public IBookService BookService => _bookService;
        public ISubscriberService SubscriberService => _subscriberService;
    }
}
