using Entities.DataManipulationObject.ProductDtos;

namespace BookSAW.Contracts
{
    public interface IBookService
    {
        List<ResultBookDto> GetAllBooks(bool trackChanges);
        List<ResultBookDto> GetBook(int id, bool trackCkanges);
        Task AddBook(CreateBookDto bookdto);
        Task EditBook(UpdateBookDto bookdto);
        Task DeleteBook(int id);
    }
}
