using BookSAW.Contracts;
using DTOs.BookDto;

namespace Services
{
    public class BookManager : IBookService
    {

        public Task AddBook(CreateBookDto bookdto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditBook(UpdateBookDto bookdto)
        {
            throw new NotImplementedException();
        }

        public List<ResultBookDto> GetAllBooks(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public List<ResultBookDto> GetBook(int id, bool trackCkanges)
        {
            throw new NotImplementedException();
        }
    }
}