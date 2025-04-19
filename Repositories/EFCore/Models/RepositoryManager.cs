using Repositories.Contracts;
using Repositories.EFCore.Context;

namespace Repositories.EFCore.Models
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<ICategoryRepository> _category;
        private readonly Lazy<IBookRepository> _product;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _category = new Lazy<ICategoryRepository>(() => new CategoryRepository(context));
            _product = new Lazy<IBookRepository>(() => new BookRepository(context));
        }

        public ICategoryRepository Category => _category.Value;

        public IBookRepository Book => _product.Value;

        public async Task SavesChangesAsync() => await _context.SaveChangesAsync();
    }
}
