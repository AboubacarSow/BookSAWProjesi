using Entities.Models;
using Entities.RequestFeatures;
using System.Linq.Dynamic.Core;

namespace Repositories.EFCore.Extensions
{
    public static class BookRepositoryExtension
    {
        public static IQueryable<Book> FilterBooks(this IQueryable<Book> books, BookParameters bookparameters)
        {
            return books.Where(b => b.Price >= bookparameters.MinPrice && b.Price <= bookparameters.MaxPrice);
        }

        public static IQueryable<Book> Search(this IQueryable<Book> books, string searchTerm)
        {
            if (String.IsNullOrWhiteSpace(searchTerm))
                return books;
            string term = searchTerm.Trim().ToLower();
            return books.Where(b => b.Name.ToLower().Contains(term));
        }

        public static IQueryable<Book> Sort(this IQueryable<Book> books, string orderByQueryString)
        {
            if (String.IsNullOrWhiteSpace(orderByQueryString))
                return books.OrderBy(b => b.Id);

            var orderQuery = OrderQueryBuilder
                .CreateOrderQueryString<Book>(orderByQueryString);

            return !String.IsNullOrWhiteSpace(orderQuery)
                 ? books.OrderBy(orderQuery) // Fix: Ensure System.Linq.Dynamic.Core is used for dynamic queries
                 : books.OrderBy(b => b.Id);
        }
    }
}
