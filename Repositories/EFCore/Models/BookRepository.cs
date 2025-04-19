using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Context;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore.Models
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneBook(Book book) => Add(book);

        public void DeleteOneBook(Book book) => Remove(book);
        public async Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParameters,bool trackChanges)
        {
            var source=await FindAll(trackChanges)
                             .FilterBooks(bookParameters)
                             .ToListAsync();

            return PagedList<Book>.ToPagedList(source, bookParameters.PageNumber, bookParameters.PageSize);
        }

        public async Task<Book>? GetOneBookByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(p => p.Id.Equals(id), trackChanges).FirstOrDefaultAsync();

        public void UpdateOneBook(Book book) => Edit(book);
        
    }
}
