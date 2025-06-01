using AutoMapper;
using DTOs.BookDtos;

namespace MVC.Infrastructure.Utilities.AutoMapper
{
    public class BookMapper:Profile
    {
        public BookMapper()
        {
            CreateMap<ResultBookDto, UpdateBookDto>();
        }
    }
}
