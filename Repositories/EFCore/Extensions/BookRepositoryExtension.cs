using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.EFCore.Extensions
{
    public static class BookRepositoryExtension
    {
        public static IQueryable<Book> FilterBooks(this IQueryable<Book> books,BookParameters bookparameters)
        {
            return books.Where(b => b.Price >= bookparameters.MinPrice && b.Price <= bookparameters.MaxPrice);
        }
    }
}
