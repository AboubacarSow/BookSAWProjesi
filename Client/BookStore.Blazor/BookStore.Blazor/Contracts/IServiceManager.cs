namespace BookStore.Blazor.Contracts;
public interface IServiceManager
{
    IBookService BookService { get; }
    ICategoryService CategoryService { get; }
}

