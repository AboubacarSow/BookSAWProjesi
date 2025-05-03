using DTOs.BookDtos;

namespace BookStore.Blazor.Contracts;
public interface IBookService
{
        Task<List<ResultBookDto>> GetAllBooksAsync();
        Task<ResultBookDto> GetBookAsync(int id);
        Task<HttpResponseMessage> AddBookAsync(CreateBookDto bookdto);
        Task<HttpResponseMessage> EditBookAsync(UpdateBookDto bookdto);
        Task<HttpResponseMessage> DeleteBookAsync(int id);
}

