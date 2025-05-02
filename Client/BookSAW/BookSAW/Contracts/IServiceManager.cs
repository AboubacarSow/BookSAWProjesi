namespace BookSAW.Contracts
{
    public interface IServiceManager
    {
        IBookService ProductService { get; }
        ICategoryService CategoryService { get; }
    }
}
