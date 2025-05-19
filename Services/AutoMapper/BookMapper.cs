using AutoMapper;
using Entities.DataManipulationObject.BookDtos;
using Entities.DataManipulationObject.ProductDtos;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class BookMapper: Profile {
        public BookMapper()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<Book, ResultBookDto>();
            CreateMap<Book, BookBannerDto>();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
        }
    }
}
