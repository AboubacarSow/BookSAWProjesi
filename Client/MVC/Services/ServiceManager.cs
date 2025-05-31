using Contracts;
using MVC.Contracts;

namespace Services;
public class ServiceManager : IServiceManager
{
    private readonly IBookService _bookService;
    private readonly ICategoryService _categoryService;
    private readonly ISubscriberService _subscriberService;
    public ServiceManager(IBookService bookService, ICategoryService categoryService, ISubscriberService subscriberService)
    {
        _bookService = bookService;
        _categoryService = categoryService;
        _subscriberService = subscriberService;
    }
    public IBookService BookService => _bookService;
    public ICategoryService CategoryService => _categoryService;

    public ISubscriberService SubscriberService => _subscriberService;
}