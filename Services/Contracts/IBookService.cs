using Entities.DataManipulationObject.BookDtos;
using Entities.DataManipulationObject.ProductDtos;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts
{
    public interface IBookService
    {
        Task<(IEnumerable<ResultBookDto>bookDtos,MetaData metaData)> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges);
        Task<ResultBookDto> GetOneBookByIdAsync(int id, bool trackChanges);
        Task CreateOneBookAsync(CreateBookDto productDto);
        Task<ResultBookDto> UpdateOneBookAsync(int Id, UpdateBookDto productDto, bool trackChanges);
        Task DeleteOneBookAsync(int id, bool trackChanges);

        Task<List<BookBannerDto>> GetAllBookBannerAsync(bool trackChanges);
        Task<(UpdateBookDto updateBookDto,Book book)> GetOneBookForPatchAsync(int id,bool trackChanges);

        Task SaveChangesForPathAsync(UpdateBookDto bookDto, Book book);

    }
}
