using MVC.Contracts;

namespace Contracts;
public interface IServiceManager
{
    IBookService BookService { get; }
    ICategoryService CategoryService { get; }
    ISubscriberService SubscriberService { get; }
}

