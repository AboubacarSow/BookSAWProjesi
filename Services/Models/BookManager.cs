using AutoMapper;
using Entities.DataManipulationObject.BookDtos;
using Entities.DataManipulationObject.ProductDtos;
using Entities.Exceptions.CategoryExceptions;
using Entities.Exceptions.ProductExceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Models
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateOneBookAsync(CreateBookDto bookDto)
        {
             await GetOneCategoryAndCheckExistAsync(bookDto.CategoryId,false);
            var book = _mapper.Map<Book>(bookDto);
             _manager.Book.CreateOneBook(book);
            await _manager.SavesChangesAsync();
        }
        private async Task<Category> GetOneCategoryAndCheckExistAsync(int id, bool trackChanges)
        {
            var category = await _manager.Category.GetCategoryByIdAsync(id, trackChanges)!;
            if (category is null)
            {
                string msg = $"Category with Id:{id} could not found";
                _logger.LogInfo(msg);
                throw new CategoryNotFoundException(id.ToString());
            }

            return category;
        }
        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            var model=await GetOneBookAndCheckExistAsync(id, trackChanges);
            _manager.Book.DeleteOneBook(model);
            await _manager.SavesChangesAsync();
            string msg = $"Book with id: {id} is successfully deleted";
            _logger.LogInfo(msg);
        }

        private async Task<Book> GetOneBookAndCheckExistAsync(int id, bool trackChanges)
        {
            var model = await _manager.Book.GetOneBookByIdAsync(id, trackChanges)!;
            if(model is null)
            {
                string msg = "Book with id:" + id +"not found";
                _logger.LogInfo(msg);
                throw new BookNotFoundException(id.ToString());
            }
            return model;
        }

        public async Task<(IEnumerable<ResultBookDto>bookDtos, MetaData metaData)> GetAllBooksAsync(BookParameters bookParameters,bool trackChanges)
        {
            var pagedListBook = await _manager.Book.GetAllBooksAsync(bookParameters, trackChanges);
            var bookDto = _mapper.Map<IEnumerable<ResultBookDto>>(pagedListBook);

            return (bookDtos: bookDto, metaData: pagedListBook.MetaData);
        }

        public async Task<ResultBookDto> GetOneBookByIdAsync(int id, bool trackChanges)
        {
            return _mapper.Map<ResultBookDto>(await GetOneBookAndCheckExistAsync(id, trackChanges));
        }

        public async Task<ResultBookDto> UpdateOneBookAsync(int Id, UpdateBookDto bookDto, bool trackChanges)
        {
            await GetOneBookAndCheckExistAsync(Id, trackChanges);
            await GetOneCategoryAndCheckExistAsync(bookDto.CategoryId, trackChanges);
            var model = _mapper.Map<Book>(bookDto);
             _manager.Book.UpdateOneBook(model);
            await _manager.SavesChangesAsync();
            string msg = $"Book with id:{Id} is updated ";
            _logger.LogInfo(msg);
            return _mapper.Map<ResultBookDto>(await GetOneBookAndCheckExistAsync(Id,false));
        }

        public async Task<(UpdateBookDto updateBookDto, Book book)> GetOneBookForPatchAsync(int id, bool trackChanges)
        {
            var book = await GetOneBookAndCheckExistAsync(id,trackChanges);
            var bookForUpdateDto = _mapper.Map<UpdateBookDto>(book);
            return (bookForUpdateDto, book);
        }

        public async Task SaveChangesForPathAsync(UpdateBookDto bookDto, Book book)
        {
            _mapper.Map(bookDto, book);
            await _manager.SavesChangesAsync();
        }

        public async Task<List<BookBannerDto>> GetAllBookBannerAsync(bool trackChanges)
        {
            var books = await _manager.Book.GetBannerBooksAsync(trackChanges);
            return _mapper.Map<List<BookBannerDto>>(books);
        }
    }
}
